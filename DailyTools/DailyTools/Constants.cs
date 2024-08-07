﻿namespace DailyTools
{

    public static class IndexConstants
    {
        public static string INDEX_DATA_ROOT_DIR = "IndexData";

        public static string NIFTY_SMALLCAP_50 = "NiftySmallCap_50.csv";
        public static string NIFTY_SMALLCAP_100 = "NiftySmallCap_100.csv";
        public static string NIFTY_SMALLCAP_250 = "NiftySmallCap_250.csv";
    }

    public static class Constants
    {
        public static string SMALLCAP_DATA_ROOT_DIR = "StockData\\SmallCap";

        public static string MF_NIPPON = "Nippon";
        public static string MF_NIPPON_FILENAME = $"nippon_smallcap.txt";

        public static string MF_QUANT = "Quant";
        public static string MF_QUANT_FILENAME = "quantdata_smallcap.txt";

        public static string MF_BANKOFINDIA = "BankOfIndia";
        public static string MF_BANKOFINDIA_FILENAME = "bankofindia_smallcap.txt";

        public static string MF_HSBC = "Hsbc";
        public static string MF_HSBC_FILENAME = "hsbc_smallcap.txt";

        public static string MF_TATA = "Tata";
        public static string MF_TATA_FILENAME = "tata_smallcap.txt";

        public static string MF_FRANKLIN = "Franklin";
        public static string MF_FRANKLIN_FILENAME = "franklin_smallcap.txt";

        public static string MF_CANARAROBECO = "CanaraRobeco";
        public static string MF_CANARAROBECO_FILENAME = "canararobeco_smallcap.txt";

        public static string MF_EDELWISE = "Edelwise";
        public static string MF_EDELWISE_FILENAME = "edelwise_smallcap.txt";

        public static string MF_INVESCO = "Invesco";
        public static string MF_INVESCO_FILENAME = "invesco_smallcap.txt";

        public static string MF_HDFC = "Hdfc";
        public static string MF_HDFC_FILENAME = "hdfc_smallcap.txt";

        public static string MF_ICICIPRUDENTIAL = "IciciPrudential";
        public static string MF_ICICIPRUDENTIAL_FILENAME = "iciciprudential_smallcap.txt";

        public static string MF_KOTAK = "Kotak";
        public static string MF_KOTAK_FILENAME = "kotak_smallcap.txt";

        public static string MF_SUNDARAM = "Sundaram";
        public static string MF_SUNDARAM_FILENAME = "sundaram_smallcap.txt";

        public static string MF_DSP = "Dsp";
        public static string MF_DSP_FILENAME = "dsp_smallcap.txt";

        public static string MF_UNION = "Union";
        public static string MF_UNION_FILENAME = "union_smallcap.txt";

        public static string MF_AXISBANK = "AxisBank";
        public static string MF_AXISBANK_FILENAME = "axisbank_smallcap.txt";

        public static string MF_SBI = "Sbi";
        public static string MF_SBI_FILENAME = "sbi_smallcap.txt";

        public static string MF_ADITYABIRLA = "AdityaBirla";
        public static string MF_ADITYABIRLA_FILENAME = "adityabirla_smallcap.txt";

        public static string GetFilePath(string dir, string filename)
        {
            return $"{dir}\\{filename}";
        }
    }
}
