using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    [Serializable]
    public class UtoiConvertException : Exception
    {
        public UtoiConvertException() { }
        public UtoiConvertException(string message) : base(message) { }
        public UtoiConvertException(string message, Exception inner) : base(message, inner) { }
        protected UtoiConvertException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
            if (info != null)
            {
                TokenIndex = info.GetInt32("TokenIndex");
            }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("TokenIndex", TokenIndex);
        }

        public int TokenIndex
        {
            get
            {
                return tokenIndex;
            }
            set
            {
                tokenIndex = value;
            }
        }

        private int tokenIndex;
    }
}
