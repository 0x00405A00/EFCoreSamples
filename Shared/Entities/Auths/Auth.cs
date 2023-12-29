using Shared.Entities.Users;
using Shared.Primitives;
using Shared.ValueObjects.Ids;

namespace Shared.Entities.Auths
{
    public sealed class Auth : Entity<AuthId>
    {
        public UserId UserId { get; private set; }
        public User User { get; set; }

        public string RemoteIp { get; private set; }
        public uint RemoteIpPort { get; private set; }
        public string LocalIp { get; private set; }
        public uint LocalIpPort { get; private set; }
        public string Token { get; private set; }
        public CustomDateTime TokenExpiresIn { get; private set; }
        public string UserAgent { get; private set; }
        public CustomDateTime RefreshTokenExpiresIn { get; private set; }
        public string RefreshToken { get; private set; }
        public CustomDateTime? LogoutTime { get; private set; }

        private Auth() : base()
        {

        }
        private Auth(
            AuthId authId,
            UserId userId,
            string remoteIp,
            uint remoteIpPort,
            string localIp,
            uint localIpPort,
            string token,
            CustomDateTime tokenExpiresIn,
            string userAgent,
            CustomDateTime refreshTokenExpiresIn,
            string refreshToken,
            CustomDateTime? logoutTime) : base()
        {
            Id = authId;
            UserId = userId;
            RemoteIp = remoteIp;
            RemoteIpPort = remoteIpPort;
            LocalIp = localIp;
            LocalIpPort = localIpPort;
            Token = token;
            TokenExpiresIn = tokenExpiresIn;
            UserAgent = userAgent;
            RefreshTokenExpiresIn = refreshTokenExpiresIn;
            RefreshToken = refreshToken;
            LogoutTime = logoutTime;
        }
        public Entity<AuthId> Create(
            AuthId authId,
            UserId userId,
            string remoteIp,
            uint remoteIpPort,
            string localIp,
            uint localIpPort,
            string token,
            CustomDateTime tokenExpiresIn,
            string userAgent,
            CustomDateTime refreshTokenExpiresIn,
            string refreshToken,
            CustomDateTime? logoutTime)
        {
            return new Auth(
            authId,
            userId,
            remoteIp,
            remoteIpPort,
            localIp,
            localIpPort,
            token,
            tokenExpiresIn,
            userAgent,
            refreshTokenExpiresIn,
            refreshToken,
            logoutTime);
        }
    }
}
