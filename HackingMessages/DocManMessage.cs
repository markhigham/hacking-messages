using System;
using System.Collections.Generic;
using Hacking.Messages;
using Hacking.Subscriptions;

namespace Hacking
{
    internal class DocManMessage : IDocManMessage
    {
        private IEnumerable<string> _steps = new List<string>();

        #region IRoutingHeaders implementation

        public IEnumerable<string> Steps
        {
            get
            {
                return _steps;
            }
            set
            {
                _steps = value;
            }
        }

        #endregion

        #region ICommonHeaders implementation

        public string MessageId
        {
            get;
            set;
        }

        public string MessageType
        {
            get;
            set;
        }

        #endregion

        #region IMessageWrapper implementation

        public string Headers { get; set; }

        public string Payload
        {
            get;
            set;
        }

        #endregion


    }
}

