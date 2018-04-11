using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PHFoodManagement;

namespace PHFoodOrderWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPHFOrderRetrievalService" in both code and config file together.
    [ServiceContract]
    public interface IPHFOrderRetrievalService
    {
        [OperationContract]
        int AddNewOrder(string o);

        [OperationContract]
        int UpdateOrder(string o);

        [OperationContract]
        string GetOrder(int id);

        [OperationContract]
        int DeleteOrder(int id);

        [OperationContract]
        string GetAllOrders();

    }

    
    
}
