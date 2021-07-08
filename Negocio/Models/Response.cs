using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negocio.Models
{
    public class Response
    {
        public enum Type
        {
            Success,
            Fail
        }
        private Type m_Type;
        private List<string> m_Messsages;
        public Response(Type t, List<string> m)
        {
            this.m_Type = t;
            this.m_Messsages = m;
        }

        public Type ReturnType { get => m_Type; set => m_Type = value; }
        public List<string> Messages { get => m_Messsages; set => m_Messsages = value; }
    }
}
