using DailyTools.Models;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;
using static DailyTools.Constants;

namespace DailyTools
{
    public static class ETMutualFundsProcess
    {
        public static void ProcessETMoneyData()
        {
            IList<MutualFund> mutualFunds = new List<MutualFund>();
            mutualFunds.Add(new MutualFund { Name = MF_NIPPON, FileName = GetFilePath(DATA_ROOT_DIR, MF_NIPPON_FILENAME) });
            mutualFunds.Add(new MutualFund { Name = MF_QUANT, FileName = GetFilePath(DATA_ROOT_DIR, MF_QUANT_FILENAME) });
            mutualFunds.Add(new MutualFund { Name = MF_BANKOFINDIA, FileName = GetFilePath(DATA_ROOT_DIR, MF_BANKOFINDIA_FILENAME) });
            mutualFunds.Add(new MutualFund { Name = MF_HSBC, FileName = GetFilePath(DATA_ROOT_DIR, MF_HSBC_FILENAME) });
            mutualFunds.Add(new MutualFund { Name = MF_TATA, FileName = GetFilePath(DATA_ROOT_DIR, MF_TATA_FILENAME) });
            mutualFunds.Add(new MutualFund { Name = MF_FRANKLIN, FileName = GetFilePath(DATA_ROOT_DIR, MF_FRANKLIN_FILENAME) });
            mutualFunds.Add(new MutualFund { Name = MF_CANARAROBECO, FileName = GetFilePath(DATA_ROOT_DIR, MF_CANARAROBECO_FILENAME) });
            mutualFunds.Add(new MutualFund { Name = MF_EDELWISE, FileName = GetFilePath(DATA_ROOT_DIR, MF_EDELWISE_FILENAME) });
            mutualFunds.Add(new MutualFund { Name = MF_INVESCO, FileName = GetFilePath(DATA_ROOT_DIR, MF_INVESCO_FILENAME) });
            mutualFunds.Add(new MutualFund { Name = MF_HDFC, FileName = GetFilePath(DATA_ROOT_DIR, MF_HDFC_FILENAME) });
            mutualFunds.Add(new MutualFund { Name = MF_ICICIPRUDENTIAL, FileName = GetFilePath(DATA_ROOT_DIR, MF_ICICIPRUDENTIAL_FILENAME) });
            mutualFunds.Add(new MutualFund { Name = MF_KOTAK, FileName = GetFilePath(DATA_ROOT_DIR, MF_KOTAK_FILENAME) });

            foreach (var fund in mutualFunds)
            {
                fund.RawDataModel = ProcessETRawDataModel(fund.FileName);
                fund.Stocks = GetStocksFromProcessedData(fund.RawDataModel);

                //Console.WriteLine($"Total Count {fund.RawDataModel.TotalLines}, Processed {fund.RawDataModel.ProcessedLines} and  failed is {fund.RawDataModel.UnProcessedLines}");
                //Console.WriteLine($"Number of stocks  {fund.Stocks.Count}");
            }

            //GenerateReport(mutualFunds);
            //GenerateReportFundWise(mutualFunds);
            string sctorName = "Capital Goods";
            GenerateSectorReport(mutualFunds, sctorName);

        }

        private static void GenerateSectorReport(IList<MutualFund> mutualFunds, string sectorName)
        {
            IDictionary<string, Stock> stockMap = new Dictionary<string, Stock>();
            List<Stock> sectorStocks = new List<Stock>();

            foreach (var fund in mutualFunds)
            {
                var sectors = fund.Stocks.Where(st => st.Sector.Equals(sectorName)).ToList();

                foreach (var stock in sectors.ToList())
                {
                    
                    if(!stockMap.ContainsKey(stock.CompanyName))
                    {
                        stockMap[stock.CompanyName] = stock;
                        stock.FundNames.Add(fund.Name);
                    }
                    else
                    {
                        stockMap[stock.CompanyName].FundNames.Add(fund.Name);
                    }
                }
            }

            string dir_path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @$"Sector");

            if(!Directory.Exists(dir_path))
            {
                Directory.CreateDirectory(dir_path);
            }
            string output = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @$"Sector\{sectorName}_report.txt");
            if (File.Exists(output))
            {
                File.Delete(output);
            }

            File.WriteAllText(output, JsonConvert.SerializeObject(stockMap.Values.OrderByDescending(s => s.FundNames.Count)));
        }

        private static void GenerateReportFundWise(IList<MutualFund> mutualFunds)
        {
            foreach (var item in mutualFunds)
            {
                string fileName = item.Name + "_sectorwise_report";
                IDictionary<string, IList<string>> sectorWiseMap = new Dictionary<string, IList<string>>();
                var stocks = item.Stocks.OrderBy(s => s.Sector).ToList();
                
                foreach (var item1 in stocks)
                {
                    if(sectorWiseMap.ContainsKey(item1.Sector))
                    {
                        sectorWiseMap[item1.Sector].Add(item1.CompanyName);
                    }
                    else
                    {
                        sectorWiseMap[item1.Sector] = new List<string> { item1.CompanyName };
                    }

                    sectorWiseMap[item1.Sector] = sectorWiseMap[item1.Sector].OrderBy(x => x).ToList();
                }

                string output = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @$"Data\{fileName}.txt");
                if(File.Exists(output))
                {
                    File.Delete(output);
                }
                File.WriteAllText(output, JsonConvert.SerializeObject(sectorWiseMap));
            }
        }

        private static void GenerateReport(IList<MutualFund> mutualFunds)
        {
            Console.WriteLine();
            Console.WriteLine();
            AnalysisModel analysisModel = new AnalysisModel();

            string fileName = GetFileName(mutualFunds);
            foreach (var item in mutualFunds)
            {

                if (analysisModel.Names.Count == 0)
                {
                    item.Stocks.ToList().ForEach(s => analysisModel.Names.Add(s.CompanyName));
                }
                else
                {
                    item.Stocks.ToList().ForEach(s => {

                        if (analysisModel.Names.Contains(s.CompanyName))
                        {
                            analysisModel.Common.Add(s.CompanyName);
                        }
                        else
                        {
                            analysisModel.Names.Add(s.CompanyName);
                            analysisModel.Unique.Add(s.CompanyName);
                        }
                    });
                }
            }

            string output = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @$"Data\{fileName}.txt");

            analysisModel.Names = null;
            //analysisModel.Names = analysisModel.Names.OrderBy(x => x).ToList();
            analysisModel.Common = analysisModel.Common.OrderBy(x => x).ToList();
            analysisModel.Unique = analysisModel.Unique.OrderBy(x => x).ToList();
            File.WriteAllText(output, JsonConvert.SerializeObject(analysisModel));
        }

        private static string GetFileName(IList<MutualFund> mutualFunds)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (mutualFunds!= null && mutualFunds.Count>0)
            {
                foreach (var item in mutualFunds)
                {
                    stringBuilder.Append(item.Name);
                    stringBuilder.Append("_");
                }
            }

            stringBuilder.Append("report");
            return stringBuilder.ToString();
        }

        private static IList<Stock> GetStocksFromProcessedData(ETRawDataModel rawdata)
        {
            IList<Stock> stocks = new List<Stock>();

            foreach (var item in rawdata.SectorSegregate)
            {
                foreach (var item1 in item.Value)
                {
                    string[] lines = item1.Split(item.Key);

                    if (lines.Length > 1)
                    {
                        Stock stock = new Stock
                        {
                            CompanyName = lines[0].Trim(),
                            Sector = item.Key,
                            HoldingPercent = GetHoldingPercent(lines[1])
                        };
                        stocks.Add(stock);
                    }
                }
            }

            return stocks;
        }

        private static string GetHoldingPercent(string data)
        {
            var str = data.Trim().Split(' ');

            if(str.Length > 1)
            {
                return str[0].Trim();
            }
            else
            {
                return "No Weightage";
            }
        }

        private static ETRawDataModel ProcessETRawDataModel(string filePath)
        {
            string sectors = "Capital Goods,Financial,Automobile,Diversified,Construction,Services,Healthcare,Consumer Staples,Textiles,Technology,Metals, Pharmaceuticals,Chemicals Ltd,Materials";

            ETRawDataModel eTRawDataModel = new ETRawDataModel();
            string[] sectorArray = sectors.Split(",");

            string fileName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), filePath);

            const Int32 BufferSize = 128;
            using (var fileStream = File.OpenRead(fileName))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    ++eTRawDataModel.TotalLines;
                    bool isExist = false;
                    foreach (string item in sectorArray)
                    {
                        if (line.Contains(item))
                        {
                            ++eTRawDataModel.ProcessedLines;
                            isExist = true;
                            if (eTRawDataModel.SectorSegregate.ContainsKey(item))
                            {
                                eTRawDataModel.SectorSegregate[item].Add(line);
                            }
                            else
                            {
                                eTRawDataModel.SectorSegregate[item] = new List<string>() { line };
                            }
                            break;
                        }
                    }

                    if (!isExist)
                    {
                        ++eTRawDataModel.UnProcessedLines;
                        eTRawDataModel.UnProcessedDataLines.Add(line);
                    }
                }
            }

            if (eTRawDataModel.TotalLines == (eTRawDataModel.ProcessedLines + eTRawDataModel.UnProcessedLines))
            {
                Console.WriteLine("All lines processed");
            }
            else
            {
                Console.WriteLine("Discripency in lines process");
            }

            Console.WriteLine();
            return eTRawDataModel;
        }
    }
}
