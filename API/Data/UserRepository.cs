using API.DTOs;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;


namespace API.Data
{
    public class userRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public userRepository(DataContext context, IMapper mapper)
        {
          _context = context;
          _mapper = mapper;
        }

        public async Task<MemberDto> GetMemberAsync(string username)
        {
            return await _context.User
            .Where(x => x.UserName == username)
            .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
             .SingleOrDefaultAsync();
        }

        public async  Task<IEnumerable<MemberDto>> GetMembersAsync()
        {
           return await _context.User
            .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
             return await _context.User.FindAsync(id);
        }
        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
           return await _context.User
           .Include(p => p.Photos)
           .SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _context.User
            .Include(p => p.Photos)
            .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync()> 0;
        }

        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}