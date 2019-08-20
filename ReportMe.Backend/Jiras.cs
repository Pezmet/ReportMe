using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportMe.Backend
{
    public class Jiras
    {
        //class used for storing information for a jira id
        public string IssueType { get; set; }
        public string Jiraid { get; set; }
        public string Jirasummary { get; set; }
        public string UbiPrio { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        private string checkNull;
        public string Regression { get; set; }


        public string Comment
        {
            get
            {
                return this.checkNull;
            }
            set
            {
                if (this.checkNull == null)
                    this.checkNull = " ";
            }
        }

        public string id_link { get; set; }

    }
}
