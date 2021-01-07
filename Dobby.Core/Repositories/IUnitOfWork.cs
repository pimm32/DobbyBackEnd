using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dobby.Core.Repositories
{
    public interface IUnitOfWork: IDisposable
    {
        IPartijRepository Partijen { get; }
        IZetRepository Zetten { get; }
        IBerichtRepository Berichten { get; }

        IChatRepository Chats { get; }
        IGebruikerRepository Gebruikers { get; }
        ISpelerRepository Spelers { get; }
        IContactRepository Contacts { get; }
        Task<int> CommitAsync();
    }
}
