using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SautiYako.Models;

namespace SautiYako.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<SpeechToText> SpeechToTexts { get; set; }
        public DbSet<TextToSpeech> TextToSpeeches { get; set; }
        public DbSet<TextToSpeechLog> TextToSpeechLogs { get; set; }
    }
}
