using CabeleleilaLeila.Application.Helpers;
using CabeleleilaLeila.Application.Interfaces;
using CabeleleilaLeila.Arguments;
using CabeleleilaLeila.Domain.Entities;
using CabeleleilaLeila.Domain.Interfaces;

namespace CabeleleilaLeila.Application.Services;

public class UserService(IUnitOfWork unitOfWork, IEmail email) : BaseService<IUserRepository, InputCreateUser, InputUpdateUser, User, OutputUser, InputIdentifierUser>(unitOfWork), IUserService
{
    private readonly IEmail _email = email;

    public override OutputUser Create(InputCreateUser inputCreate)
    {
        User? originalUser = _repository!.GetByIdentifier(new InputIdentifierUser(inputCreate.Email!));

        if (originalUser is not null)
            throw new InvalidOperationException($"Email '{inputCreate.Email}' já cadastrado na base de dados.");

        User user = FromInputCreateToEntity(inputCreate).SetProperty(nameof(User.Type), EnumTypeUser.Default);
        var entity = _repository.Create(user) ?? throw new InvalidOperationException("Falha ao criar o usuário.");
        _unitOfWork!.Commit();

        return FromEntityToOutput(entity);
    }

    public override OutputUser Update(long id, InputUpdateUser inputUpdate)
    {
        User? originalUser = _repository!.Get(x => x.Id == id) ?? throw new KeyNotFoundException($"Não foi encontrado nenhum usuário correspondente a este Id.");

        User user = UpdateEntity(originalUser, inputUpdate) ?? throw new Exception("Problemas para realizar atualização");
        var entity = _repository!.Update(user) ?? throw new InvalidOperationException("Falha ao atualizar o usuário.");
        _unitOfWork!.Commit();

        return FromEntityToOutput(entity);
    }

    public override bool Delete(long id)
    {
        User? originalUser = _repository!.Get(x => x.Id == id) ?? throw new KeyNotFoundException($"Não foi encontrado nenhum usuário correspondente a este Id.");

        if (originalUser.ListScheduled?.Count > 0)
            throw new InvalidOperationException($"Esse usuário possui vínculo com agendamentos");

        _repository.Delete(originalUser);
        _unitOfWork!.Commit();

        return true;
    }

    public OutputUser Login(InputLoginUser input)
    {
        var user = _repository!.GetByIdentifier(new InputIdentifierUser(input.Email!));

        if (user != null)
        {
            if (user.Password == input.Password)
                return FromEntityToOutput(user);
            else
                throw new InvalidOperationException("Senha incorreta.");
        }

        throw new InvalidOperationException("Email inválido.");
    }

    public bool SendLinkToRedefinePassword(InputSendLinkToRedefinePasswordUser input)
    {
        var user = _repository!.GetByIdentifier(new InputIdentifierUser(input.Email!));

        if (user != null)
        {
            string newPassword = Guid.NewGuid().ToString()[..8];
            user.SetProperty(nameof(User.Password), newPassword);
            bool sent = _email.Send(user.Email!, "CabeleleilaLeila - Nova Senha", $"Sua nova senha é: {newPassword}");
            if (sent)
            {
                _repository.Update(user);
                _unitOfWork!.Commit();
                return true;
            }
            else
                throw new InvalidOperationException("Ocorreu um erro ao enviar o e-mail. Tente novamente.");
        }

        throw new InvalidOperationException("Email inválido.");
    }

    public bool RedefinePassword(InputRedefinePasswordUser input)
    {
        var user = _repository!.GetByIdentifier(new InputIdentifierUser(input.Email!));

        if (user != null)
        {
            if (user.Password == input.OldPassword)
            {
                user.SetProperty(nameof(User.Password), input.NewPassword);
                _repository.Update(user);
                _unitOfWork!.Commit();
                return true;
            }
            else
                throw new InvalidOperationException("Senha antiga incorreta.");
        }

        throw new InvalidOperationException("Email inválido.");
    }
}