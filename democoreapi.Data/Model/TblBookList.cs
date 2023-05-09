using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace democoreapi.Data.Model
{
    [Table("TblBookList")]
    public class TblBookList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Bid { get;set; }
        public string bCode { get; set; }
        public string bName { get; set; }
        public string bType { get; set; }
    }



}
