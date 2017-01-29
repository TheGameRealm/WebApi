namespace Data.Repositories
{
    using AutoMapper;
    using Common.DTOs.Alexa;
    using Data.Entities.Alexa;
    using Data.Entity;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AlexaRepository : RepositoryBase, IAlexaRepository
    {
        public AlexaRepository(RealmContext context) : base(context)
        {

        }

        public AlexaRequestDTO Create(AlexaRequestDTO alexaRequestDTO)
        {
            using (var transaction = base.Context.Database.BeginTransaction())
            {
                var alexaMember = base.Context.AlexaMembers.SingleOrDefault(m => m.AlexaUserId == alexaRequestDTO.UserId);

                if (alexaMember == null)
                {
                    alexaMember = new AlexaMember()
                    {
                        AlexaUserId = alexaRequestDTO.UserId,
                        CreatedDate = DateTime.UtcNow,
                        LastRequestDate = DateTime.UtcNow,
                        RequestCount = 1
                    };

                    base.Context.Entry(alexaMember).State = EntityState.Added;
                }
                else
                {
                    alexaMember.RequestCount++;
                    alexaMember.LastRequestDate = DateTime.UtcNow;
                    base.Context.Entry(alexaMember).State = EntityState.Modified;
                }
                base.Context.SaveChanges();

                var alexaRequest = Mapper.Map<AlexaRequest>(alexaRequestDTO);
                base.Context.Entry(alexaRequest).State = EntityState.Added;
                base.Context.SaveChanges();

                transaction.Commit();

                return Mapper.Map<AlexaRequestDTO>(alexaRequest);
            }
        }

    }
}
