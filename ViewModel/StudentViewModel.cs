using managment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace managment.ViewModel
{
    public class StudentViewModel
    {
        public IEnumerable<st_fees> st_fees { get; set; }

        public IEnumerable<st_subj> st_subj { get; set; }

        public IEnumerable<std_mat> std_mat { get; set; }

        public IEnumerable<exam> exam { get; set; }

        public IEnumerable<Assingment> Assingment { get; set; }
        public IEnumerable<notice> notice { get; set; }

        public IEnumerable<as_submit> as_submit { get; set; }

        public IEnumerable<exam_result> exam_result { get; set; }



    }
}