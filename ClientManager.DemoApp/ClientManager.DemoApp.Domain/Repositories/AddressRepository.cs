using System.Collections.Generic;
using ClientManager.DemoApp.Domain.Enums;
using ClientManager.DemoApp.Domain.Models;
using ClientManager.DemoApp.Domain.Repositories.Interfaces;

namespace ClientManager.DemoApp.Domain.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        public AddressRepository()
        {

        }
        public IEnumerable<Address> GetAddressesByAddressType(AddressType addressType)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Address> GetAddressesByClientId(int clientId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Address> GetAddressesByKeyword(string keyword)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Address> GetAllAddresses()
        {
            throw new System.NotImplementedException();
        }

        public int InsertAddressToClient(int clientId, Address address)
        {
            throw new System.NotImplementedException();
        }

        public int RemoveAddressFromClient(int clientId, Address addressToRemove)
        {
            throw new System.NotImplementedException();
        }

        public int UpdateAddressOnClient(int clientId, Address addressToUpdate)
        {
            throw new System.NotImplementedException();
        }
    }
}
