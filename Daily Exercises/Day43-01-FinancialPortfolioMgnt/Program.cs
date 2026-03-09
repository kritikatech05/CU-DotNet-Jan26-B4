using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace PortfolioManagementSystem
{
    interface IRiskAssessable
    {
        string GetRiskCategory();
    }

    interface IReportable
    {
        string GenerateReportLine();
    }

    class InvalidFinancialDataException : Exception
    {
        public InvalidFinancialDataException(string message) : base(message) { }
    }

    abstract class FinancialInstrument
    {
        private int quantity;
        private decimal purchasePrice;
        private decimal marketPrice;
        private string currency;

        public string InstrumentID { get; set; }
        public string Name { get; set; }
        public DateOnly PurchaseDate { get; set; }

        public string Currency
        {
            get { return currency; }
            set
            {
                if (value.Length != 3)
                    throw new InvalidFinancialDataException("Currency must be a 3 letter code");

                currency = value.ToUpper();
            }
        }

        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value < 0)
                    throw new InvalidFinancialDataException("Quantity cannot be negative");

                quantity = value;
            }
        }

        public decimal PurchasePrice
        {
            get { return purchasePrice; }
            set
            {
                if (value < 0)
                    throw new InvalidFinancialDataException("Invalid purchase price");

                purchasePrice = value;
            }
        }

        public decimal MarketPrice
        {
            get { return marketPrice; }
            set
            {
                if (value < 0)
                    throw new InvalidFinancialDataException("Invalid market price");

                marketPrice = value;
            }
        }

        public virtual decimal CalculateCurrentValue()
        {
            return Quantity * MarketPrice;
        }

        public virtual string GetInstrumentSummary()
        {
            return $"{InstrumentID} - {Name} ({Currency}) Units:{Quantity}";
        }
    }

    class Equity : FinancialInstrument, IRiskAssessable, IReportable
    {
        public string GetRiskCategory()
        {
            return "High";
        }

        public string GenerateReportLine()
        {
            return $"{InstrumentID} | Equity | {Name} | Value: {CalculateCurrentValue():C}";
        }
    }

    class Bond : FinancialInstrument, IRiskAssessable, IReportable
    {
        public string GetRiskCategory()
        {
            return "Medium";
        }

        public string GenerateReportLine()
        {
            return $"{InstrumentID} | Bond | {Name} | Value: {CalculateCurrentValue():C}";
        }
    }

    class FixedDeposit : FinancialInstrument, IRiskAssessable, IReportable
    {
        public string GetRiskCategory()
        {
            return "Low";
        }

        public string GenerateReportLine()
        {
            return $"{InstrumentID} | Fixed Deposit | {Name} | Value: {CalculateCurrentValue():C}";
        }
    }

    class MutualFund : FinancialInstrument, IRiskAssessable, IReportable
    {
        public string GetRiskCategory()
        {
            return "High";
        }

        public string GenerateReportLine()
        {
            return $"{InstrumentID} | Mutual Fund | {Name} | Value: {CalculateCurrentValue():C}";
        }
    }

    class Transaction
    {
        public string TransactionId { get; set; }
        public string InstrumentId { get; set; }
        public string Type { get; set; }
        public int Units { get; set; }
        public DateOnly Date { get; set; }
    }

    class Portfolio
    {
        private List<FinancialInstrument> instruments = new List<FinancialInstrument>();
        private Dictionary<string, FinancialInstrument> instrumentMap = new Dictionary<string, FinancialInstrument>();

        public void AddInstrument(FinancialInstrument instrument)
        {
            if (instrumentMap.ContainsKey(instrument.InstrumentID))
                throw new InvalidFinancialDataException("Instrument ID already exists");

            instruments.Add(instrument);
            instrumentMap[instrument.InstrumentID] = instrument;
        }

        public void RemoveInstrument(string id)
        {
            if (!instrumentMap.ContainsKey(id))
                return;

            FinancialInstrument inst = instrumentMap[id];

            instruments.Remove(inst);
            instrumentMap.Remove(id);
        }

        public FinancialInstrument FindInstrument(string id)
        {
            if (instrumentMap.ContainsKey(id))
                return instrumentMap[id];

            return null;
        }

        public decimal CalculateTotalValue()
        {
            return instruments.Sum(i => i.CalculateCurrentValue());
        }

        public List<FinancialInstrument> FilterByRisk(string riskLevel)
        {
            return instruments
                .Where(i => i is IRiskAssessable r && r.GetRiskCategory().Equals(riskLevel, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<FinancialInstrument> GetAllInstruments()
        {
            return instruments;
        }

        public void ApplyTransaction(Transaction transaction)
        {
            if (!instrumentMap.ContainsKey(transaction.InstrumentId))
                throw new InvalidFinancialDataException("Instrument not found");

            FinancialInstrument instrument = instrumentMap[transaction.InstrumentId];

            if (transaction.Type.Equals("Buy", StringComparison.OrdinalIgnoreCase))
            {
                instrument.Quantity += transaction.Units;
            }
            else
            {
                if (instrument.Quantity < transaction.Units)
                    throw new InvalidFinancialDataException("Not enough units to sell");

                instrument.Quantity -= transaction.Units;
            }
        }
    }

    class ReportGenerator
    {
        public void PrintConsoleReport(Portfolio portfolio)
        {
            var instrumentsList = portfolio.GetAllInstruments();

            Console.WriteLine("\n===== PORTFOLIO SUMMARY =====\n");

            var groupedData = instrumentsList.GroupBy(i => i.GetType().Name);

            foreach (var group in groupedData)
            {
                decimal totalInvestment = group.Sum(x => x.PurchasePrice * x.Quantity);
                decimal currentValue = group.Sum(x => x.CalculateCurrentValue());

                Console.WriteLine($"Instrument Type: {group.Key}");
                Console.WriteLine($"Investment: {totalInvestment:C}");
                Console.WriteLine($"Current Value: {currentValue:C}");
                Console.WriteLine($"Profit/Loss: {(currentValue - totalInvestment):C}\n");
            }

            Console.WriteLine($"Overall Portfolio Value: {portfolio.CalculateTotalValue():C}\n");

            var riskSummary = instrumentsList
                .OfType<IRiskAssessable>()
                .GroupBy(r => r.GetRiskCategory());

            Console.WriteLine("Risk Distribution:");

            foreach (var r in riskSummary)
            {
                Console.WriteLine($"{r.Key} Risk : {r.Count()} instruments");
            }
        }

        public void ExportFileReport(Portfolio portfolio)
        {
            string filename = $"PortfolioReport_{DateTime.Now:yyyyMMdd}.txt";

            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine("PORTFOLIO REPORT");
                writer.WriteLine($"Generated On: {DateTime.Now}");
                writer.WriteLine("--------------------------------");

                foreach (var inst in portfolio.GetAllInstruments())
                {
                    if (inst is IReportable rep)
                        writer.WriteLine(rep.GenerateReportLine());
                }

                writer.WriteLine("--------------------------------");
                writer.WriteLine($"Total Portfolio Value: {portfolio.CalculateTotalValue():C}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Portfolio portfolio = new Portfolio();

            Equity equity = new Equity
            {
                InstrumentID = "EQ001",
                Name = "INFY",
                Currency = "INR",
                Quantity = 100,
                PurchasePrice = 1500,
                MarketPrice = 1650,
                PurchaseDate = new DateOnly(2024, 1, 1)
            };

            Bond bond = new Bond
            {
                InstrumentID = "BD001",
                Name = "GovBond",
                Currency = "INR",
                Quantity = 200,
                PurchasePrice = 1000,
                MarketPrice = 1100,
                PurchaseDate = new DateOnly(2023, 5, 1)
            };

            MutualFund mf = new MutualFund
            {
                InstrumentID = "MF001",
                Name = "AxisGrowth",
                Currency = "INR",
                Quantity = 50,
                PurchasePrice = 2000,
                MarketPrice = 2300,
                PurchaseDate = new DateOnly(2024, 3, 1)
            };

            FixedDeposit fd = new FixedDeposit
            {
                InstrumentID = "FD001",
                Name = "HDFCFD",
                Currency = "INR",
                Quantity = 10,
                PurchasePrice = 10000,
                MarketPrice = 10500,
                PurchaseDate = new DateOnly(2022, 6, 1)
            };

            portfolio.AddInstrument(equity);
            portfolio.AddInstrument(bond);
            portfolio.AddInstrument(mf);
            portfolio.AddInstrument(fd);

            Transaction[] transactions =
            {
                new Transaction{TransactionId="T1",InstrumentId="EQ001",Type="Buy",Units=10,Date=new DateOnly(2025,1,1)},
                new Transaction{TransactionId="T2",InstrumentId="BD001",Type="Sell",Units=20,Date=new DateOnly(2025,2,1)}
            };

            List<Transaction> transactionList = transactions.ToList();

            foreach (var t in transactionList)
            {
                portfolio.ApplyTransaction(t);
            }

            ReportGenerator report = new ReportGenerator();

            report.PrintConsoleReport(portfolio);
            report.ExportFileReport(portfolio);
        }
    }
}