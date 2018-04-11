using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PHFoodOrderWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOrderRetrievalService" in both code and config file together.
    [ServiceContract]
    public interface IOrderRetrievalService
    {
        [OperationContract]
        void DoWork();
    }
}
