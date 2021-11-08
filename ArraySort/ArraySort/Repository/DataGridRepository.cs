using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Routing;
using ArraySort.Models;
using Newtonsoft.Json;

namespace ArraySort.Repository
{
    public class DataGridRepository : Model
    {
        DataGridModel _model;
        public DataGridRepository()
        {
            _model = new DataGridModel();
        }
        public dynamic Convert()
        {
            dynamic retval = null;
            _model = JsonConvert.DeserializeObject<DataGridModel>(Data);

            List<List<string>> rt = JsonConvert.DeserializeObject<List<List<string>>>(_model.textArea);
            string brand = string.Empty, ctype = string.Empty, transmission = string.Empty;

            List<List<string>> newList = new List<List<string>>();
            foreach(List<string> ls in rt)
            {
                string idx0 = ls[0];
                string idx1 = ls[1];
                string idx2 = ls[2];
                string price = ls[3];

                List<string> temp = new List<string>();

                temp.Add(emptyIfNotEqual(brand, idx0));
                brand = idx0;

                temp.Add(emptyIfNotEqual(ctype, idx1));
                ctype = idx1;
                
                temp.Add(emptyIfNotEqual(transmission, idx2));
                transmission = idx2;
                
                temp.Add(price);
                newList.Add(temp);
            }
            _model.textArea = JsonConvert.SerializeObject(newList);
            retval = _model;
            return retval;
        }
        private string emptyIfNotEqual(string a, string b)
        {
            return string.Equals(a, b) ? string.Empty : b;
        }
    }
}