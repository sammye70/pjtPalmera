using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjPalmera.Entities
{
    public class  ResultEntity
    {
        private string strResult;

        public string StrResult
        {
            get { return strResult; }
            set { strResult = value; }
        }
        
    }

    public enum setResult
    {
        Error,
        Satisfactoriamente,
        NoSatisfactoriamente,
        Campos_requeridos
    }
}
