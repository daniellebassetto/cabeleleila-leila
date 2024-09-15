using CabeleleilaLeila.Arguments;
using CabeleleilaLeila.Domain.Entities;
using CabeleleilaLeila.Domain.Interfaces;

namespace CabeleleilaLeila.Infraestructure.Repositories;

public class ScheduledRepository(CabeleleilaLeilaContext context) : BaseRepository<Scheduled, InputIdentifierScheduled>(context), IScheduledRepository { }