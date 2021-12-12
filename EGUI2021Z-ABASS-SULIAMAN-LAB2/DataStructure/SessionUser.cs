namespace EGUI2021Z_ABASS_SULIAMAN_LAB2.DataStructure
{
    public class SessionUser
    {
        private static readonly Lazy<SessionUser> lazy = new Lazy<SessionUser>(() => new SessionUser());

        public static SessionUser Instance { get { return lazy.Value; } }

        public string userName { get; set; }
        public DateTime date { get; set; }

    }
}
