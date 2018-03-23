using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EohiSHM.Models
{
    [Table("web_confoption")]
    public class ConfOption
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Title { get; set; }
        private int? allowbuyerreg;
        /// <summary>
        /// 货物ID
        /// </summary>
        public int? Allowbuyerreg
        {
            get { return allowbuyerreg; }
            set { allowbuyerreg = value; }
        }
        private string zipcode;
        /// <summary>
        /// catid
        /// </summary>
        public string Zipcode
        {
            get { return zipcode; }
            set { zipcode = value; }
        }

        private string address;
        /// <summary>
        /// 货物名
        /// </summary>
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string tel;
        /// <summary>
        /// 货物空间
        /// </summary>
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }
        private string fax;
        /// <summary>
        /// 货物记录
        /// </summary>
        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }


        private string seotxt;
        private string description;
        public string Seotxt
        {
            get { return seotxt; }
            set { seotxt = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }



        private string copyright;

        public string Copyright
        {
            get { return copyright; }
            set { copyright = value; }
        }
        private string ipccode;

        public string Ipccode
        {
            get { return ipccode; }
            set { ipccode = value; }
        }
        private string gongancode;

        public string Gongancode
        {
            get { return gongancode; }
            set { gongancode = value; }
        }

    }
}
