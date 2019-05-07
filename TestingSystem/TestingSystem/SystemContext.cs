using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Models;

namespace TestingSystem
{
    public class SystemContext : DbContext
    {
        public DbSet<test> tests { get; set; }
        public DbSet<question> questions { get; set; }
        public DbSet<answer_option> answer_options { get; set; }
        public DbSet<user> users { get; set; }
        public DbSet<passing> passings { get; set; }

        public SystemContext() : base()
        { }

        protected override void OnModelCreating(DbModelBuilder mb)
        {
            base.OnModelCreating(mb);

            //Config *test* fields
            mb.Entity<test>().Property(t => t.name)
                               .HasColumnType("nvarchar")
                               .HasMaxLength(300)
                               .IsRequired();

            //Config *question* fields
            mb.Entity<question>().Property(q => q.title)
                               .HasColumnType("nvarchar")
                               .HasMaxLength(1000)
                               .IsRequired();
            mb.Entity<question>().Property(q => q.picturePath)
                               .HasColumnType("nvarchar")
                               .HasMaxLength(4000);
            mb.Entity<question>().Property(q => q.isManyAnswers).IsRequired();
            mb.Entity<question>().Property(q => q.weight).IsRequired();

            //Config *answer_option* fields
            mb.Entity<answer_option>().Property(a => a.text)
                             .HasColumnType("nvarchar")
                             .HasMaxLength(4000)
                             .IsRequired();
            mb.Entity<answer_option>().Property(a => a.isRight).IsRequired();

            //Config *user* fields
            mb.Entity<user>().Property(u => u.login)
                            .HasColumnType("varchar")
                            .HasMaxLength(60)
                            .IsRequired();
            mb.Entity<user>().Property(u => u.password)
                           .HasColumnType("varchar")
                           .HasMaxLength(30)
                           .IsRequired();
            mb.Entity<user>().Property(u => u.firstname)
                          .HasColumnType("nvarchar")
                          .HasMaxLength(50)
                          .IsRequired();
            mb.Entity<user>().Property(u => u.lastname)
                          .HasColumnType("nvarchar")
                          .HasMaxLength(50)
                          .IsRequired();
            mb.Entity<user>().Property(u => u.isAdmin).IsRequired();

            //Config *passing* fields
            mb.Entity<passing>().Property(p => p.date)
                            .HasColumnType("date")
                            .IsRequired();
            mb.Entity<passing>().Property(p => p.passed).IsRequired();

            //Config relations
            mb.Entity<question>()
                 .HasRequired<test>(ques => ques.test)
                 .WithMany(test => test.questions)
                 .HasForeignKey(ques => ques.testId)
                 .WillCascadeOnDelete(false);

            mb.Entity<answer_option>()
                .HasRequired<question>(answer => answer.question)
                .WithMany(ques => ques.answer_options)
                .HasForeignKey(answer => answer.questionId)
                .WillCascadeOnDelete(false);

            mb.Entity<passing>()
                .HasRequired<test>(passing => passing.test)
                .WithMany(test => test.passings)
                .HasForeignKey(passing => passing.testId)
                .WillCascadeOnDelete(false);

            mb.Entity<passing>()
                .HasRequired<user>(passing => passing.user)
                .WithMany(user => user.passings)
                .HasForeignKey(passing => passing.userId)
                .WillCascadeOnDelete(false);
        }
    }
}
