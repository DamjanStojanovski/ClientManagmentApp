using ClientManager.DemoApp.Domain.Enums;
using ClientManager.DemoApp.Domain.Models;
using System.Collections.Generic;

namespace ClientManager.DemoApp.Domain.Repositories.Interfaces
{
    public interface IAddressRepository
    {
        IEnumerable<Address> GetAllAddresses();
        IEnumerable<Address> GetAddressesByKeyword(string keyword);
        IEnumerable<Address> GetAddressesByAddressType(AddressType addressType);
        IEnumerable<Address> GetAddressesByClientId(int clientId);
        int InsertAddressToClient(int clientId, Address address);
        int RemoveAddressFromClient(int clientId, Address addressToRemove);
        int UpdateAddressOnClient(int clientId, Address addressToUpdate);
    }
}
