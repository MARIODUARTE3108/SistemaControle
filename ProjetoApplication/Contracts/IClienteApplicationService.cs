using ProjetoApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoApplication.Contracts
{
    public interface IClienteApplicationService : IDisposable
    {
        void add(ClienteModel model);
        void remove(ClienteModel model);
        void modify(ClienteModel model);
        void GetAll(ClienteModel model);
    }
}
