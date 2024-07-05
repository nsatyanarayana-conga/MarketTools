using DailyTools.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DailyTools
{
    public static class ToolUtil
    {
        public static void ListFiles()
        {
            DirectoryInfo d = new DirectoryInfo("C:\\temp\\DllData"); //Assuming Test is your Folder

            FileInfo[] Files = d.GetFiles("*.txt"); //Getting Text files
            string str = "";

            foreach (FileInfo file in Files)
            {
                Console.WriteLine(Path.GetFileNameWithoutExtension(file.Name));
            }
        }

        public static void DisplayBundleIds()
        {
            string output = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\DataOutput1.txt");
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\LibraryObjectId4.txt");

            var jsonData = System.IO.File.ReadAllText(path);
            PMLRoot pmlroot = JsonConvert.DeserializeObject<PMLRoot>(jsonData);

            //pmlroot.Data.ForEach(data => { Console.WriteLine($"\"{data.LibraryObjectId}\","); });

            if (!File.Exists(output))
            {
                File.Create(output);
            }

            //string ids1 = "5c64ba3c-e1d1-4e7f-8c52-9d4429cbbf3d,a093aa52-3051-42eb-841c-788c78e15ff0,223099fd-6568-47cb-8348-bebfdbad5325,92660f94-520b-4b8c-bf7f-5e316b28319f,ce580331-23fd-49f2-9951-1f279a8399ce,b6bc92ee-5159-4848-a135-1dfce4c83ae0,28304e67-7989-47f2-8354-12c1cba834f9,5c150a76-bea2-4a3c-9cbb-fa90cfcb7667,da2e739c-e2b2-4454-b2fe-466838d51a11,d68b25d9-bde4-4d17-be26-d3105b16d92e,a2ab2732-0252-4010-be87-55154688f667,ead3e5a0-82a7-4f35-8b91-6573ff7834d5,e3a00ea2-074f-4b86-9b36-ceee81e26697,1d4a1057-9610-4e92-bbb9-a8a285737df4,6996fcc1-ee6d-4b22-a338-a4aaf86bb93a,703d7868-0f49-4506-93e4-4d36254fea89,fbf87aae-6df2-4536-a1f1-60ec344e0b44,3368013f-ca14-4094-ae6d-ba08bd0dc6b2,29bf81e9-913b-4685-9449-945ac3093e84,75cf65f5-fa08-4ce4-8609-684072b55170,4ae9291d-0740-423f-8184-d86e062516dc,3e8060bb-2ccd-45a5-a024-f0b7bc1b0ca1,591a3f69-7adf-44b2-a40d-06b9e72fe22c,76f9f10f-98f1-45ba-8733-edcba1d093c2,a92c3de8-aea6-4573-aef7-f942a9ae9d12,a66d8ecb-3586-446c-9d74-590ac6216699,902e108e-aabf-456f-9814-2dee4047e96e,4fd43d2a-466b-4c96-a9d4-73fab0ffc6cd,2e072eee-5845-4372-87a0-27959cf6bdae,3ce2dc66-3288-463b-93a3-d99d461823fc,454767eb-f1c1-45a4-9f89-8bc1e35a2037,ca2cb049-12fa-4d70-a4cc-166bd8d7c0ce,d7f90082-eb92-4ca5-933c-79e1d5117a34,82ca7c48-7ae0-445a-85dd-53d772ae1b0d,a8631961-a4eb-4a4a-ad59-4f20c4c1f65e,3fee3119-d062-4204-8390-fc0a689f5130,6b2e9d82-a3db-4fd7-b12b-96d3673e93fc,4929204f-deed-4570-a07a-9774b742bca7,49f312c7-43bc-4be6-90ed-f43e7143f9ff,717b6dd8-1472-4e6c-acba-f5924ff6f836,5b74c50d-bf13-41d7-a0a7-fe58b93119fc,7fe7b887-c348-4128-8367-b6f89041d325,07afe467-ad9f-4fe2-8104-e32a92396e24,1ecde1ad-f7e3-4428-918d-fddab46f0f3c,449232dc-4bea-4fbf-bb70-0a208c77294f,41f37a37-29b4-4d26-9cd9-030ed1c18365,4240231a-9f31-48d0-a18b-6f5c8e878d8a,6bbd8910-e756-49b9-b20c-762e3fd49c2c,2fa469b5-bdab-4e4d-a3fa-5b3a1e43b0ee,4a8f65cc-068a-47ed-90e2-ac953fdb9a3d,62f3ad4d-01ab-4f9d-876a-c2807ef5ff90,5f2ea392-2249-4f45-a426-f0a804e8c771,01263fa9-bce5-40c9-b84b-a891d083db1b,6d450b37-bfe6-4f9e-8177-f1f98507ee02,a551ea19-988d-49cc-a723-61d63eae8f8b,8c922159-2389-4eee-b613-1d26ecedb653,16e70a13-c7f7-474f-a2e7-0e8529585618,4b173d4f-978c-49dd-abe3-5b0e60279f18,8f0017c0-5f4f-43f3-91b6-c8cfca21d451,e7eda990-af60-4821-b0f6-39f2baf344a5,070e358e-6201-4d82-bab4-11829bacce61,85b2e9b5-a3b9-4d39-834c-71852f349939,1f023353-0898-43cb-933c-3927a1070082,38767b0e-0fdd-405d-a7f7-534dcebed704,df40d1bd-11da-488b-9691-1a8be7aeaf68,9e8def2f-7bb4-4711-b15f-55844e201559,9759e318-4491-407d-a63c-bb92e0a3b80f,9d24810b-8ec7-4d29-8358-e277760e2ff1,f8c76c37-03eb-4811-9454-e6bbb18d6b19,e5a6b57a-f596-41ce-a31c-f28d6c7e1a2a,d315d9e6-4c27-4668-9676-4021caf55603,c9a947c9-7745-477a-9d7d-89abc3bff641,497c5b02-2767-45f0-ba6f-d5c37f0173cd,95aa4ad1-79f7-49ab-874a-c2f955cfc98a,dac3c069-ec0c-4d33-8194-e7ad5e62d254,374f03fc-a4fc-4854-a1d3-ed4ed657963a,75410e87-acf8-419d-aa29-0a3477ec4163,72de5049-0b22-4b58-936f-f476552ea4f5,f8ae5dc2-656a-4ec5-b1e8-f29ec9b5103a,f6fed743-eb72-4605-8d03-729c5107123b,ba49b910-434b-4058-89ad-47efc9e9ef22,a00ff0e2-76c8-469b-964b-b23c50f75f8f,9c9444cb-edef-4cb8-98ba-c837e3d3782a,38aec048-fa4f-4c1f-8e35-e0462f76650c,60c283e3-b054-4dd4-a7f9-16c3e3b4cb89,2015b229-0728-4a58-b6cc-10c513415931,9217c36d-da20-49d2-b18f-8c346ea9cd96,bc5539d7-9dbe-4bc9-8918-ec4768b1ba48,b0d1350d-e5dc-4594-b063-2a715ddddbb3,c2f35e07-50ec-40b5-95d6-b615c2a4d77a,346c1100-3b87-4517-875a-c11b021eb20e,2777396e-9f8e-4cf9-9b7a-aba3ddcf55ab,3472cccf-2040-4f81-b655-86214dda9472,bc79e6d7-3f72-4844-b8ec-3c928b8aab1d,6899d68f-a04a-4903-9da7-565eaea0ee25,53ccf1a9-6b6e-4319-8f7c-2a42b7f2437b,7e29b9ad-c116-4a30-9dfb-85f098d5a511,1ad8dd02-3bbc-4e65-b1d7-a6cee16a4326,d1019197-3517-4699-a98e-5a495f7f9bda,8fbf38d1-65eb-460f-a461-01f5bdfec088";

            //var invalid = ids1.Split(",").ToList();
            List<string> ids = new List<string>();
            foreach (DataPML data in pmlroot.Data)
            {
                ids.Add(data.BundleId);

            }

            //File.WriteAllText(output, string.Join(",", ids));
            File.WriteAllText(output, JsonConvert.SerializeObject(ids));
            Console.WriteLine($"Data loaded is {pmlroot.Data.Count}");
        }

       
    }
}
