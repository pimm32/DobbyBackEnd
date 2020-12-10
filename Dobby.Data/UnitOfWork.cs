using Dobby.Core.Repositories;
using Dobby.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dobby.Data
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly DobbyDbContext _context;
        private PartijRepository _partijRepository;
        private ZetRepository _zetRepository;
        private BerichtRepository _berichtRepository;
        private ChatRepository _chatRepository;
        private GebruikerRepository _gebruikerRepository;
        private SpelerRepository _spelerRepository;

        public UnitOfWork(DobbyDbContext context)
        {
            this._context = context;
        }

        public IZetRepository Zetten => _zetRepository = _zetRepository ?? new ZetRepository(_context);
        public IPartijRepository Partijen => _partijRepository = _partijRepository ?? new PartijRepository(_context);
        public IBerichtRepository Berichten => _berichtRepository = _berichtRepository ?? new BerichtRepository(_context);
        public IChatRepository Chats => _chatRepository = _chatRepository ?? new ChatRepository(_context);
        public IGebruikerRepository Gebruikers => _gebruikerRepository = _gebruikerRepository ?? new GebruikerRepository(_context);
        public ISpelerRepository Spelers => _spelerRepository = _spelerRepository ?? new SpelerRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
