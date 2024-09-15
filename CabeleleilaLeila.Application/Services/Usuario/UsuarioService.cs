using CabeleleilaLeila.Arguments;
using CabeleleilaLeila.Domain.Entities;
using CabeleleilaLeila.Domain.Interfaces;
using CabeleleilaLeila.Application.Interfaces;
using CabeleleilaLeila.Application.Helpers;

namespace CabeleleilaLeila.Application.Services;

public class UsuarioService(IUnitOfWork unitOfWork, IEmail email) : BaseService<IUsuarioRepository, InputCreateUsuario, InputUpdateUsuario, Usuario, OutputUsuario, InputIdentifierUsuario>(unitOfWork), IUsuarioService
{
    private readonly IEmail _email = email;

    public override OutputUsuario Create(InputCreateUsuario inputCreate)
    {
        Usuario? originalCustomer = _repository!.GetByIdentifier(new InputIdentifierUsuario(inputCreate.Email!));

        if (originalCustomer is not null)
            throw new InvalidOperationException($"Email '{inputCreate.Email}' já cadastrado na base de dados.");

        Usuario customer = FromInputCreateToEntity(inputCreate);
        var entity = _repository.Create(customer) ?? throw new InvalidOperationException("Falha ao criar o usuário.");
        _unitOfWork!.Commit();

        return FromEntityToOutput(entity);
    }

    public override OutputUsuario Update(long id, InputUpdateUsuario inputUpdate)
    {
        Usuario? originalCustomer = _repository!.Get(x => x.Id == id) ?? throw new KeyNotFoundException($"Não foi encontrado nenhum usuário correspondente a este Id.");

        Usuario customer = UpdateEntity(originalCustomer, inputUpdate) ?? throw new Exception("Problemas para realizar atualização");
        var entity = _repository!.Update(customer) ?? throw new InvalidOperationException("Falha ao atualizar o usuário.");
        _unitOfWork!.Commit();

        return FromEntityToOutput(entity);
    }

    public override bool Delete(long id)
    {
        Usuario? originalCustomer = _repository!.Get(x => x.Id == id) ?? throw new KeyNotFoundException($"Não foi encontrado nenhum usuário correspondente a este Id.");

        //if (originalCustomer.ListOrder?.Count > 0)
        //    throw new InvalidOperationException($"Esse usuário possui vínculo com pedidos");

        _repository.Delete(originalCustomer);
        _unitOfWork!.Commit();

        return true;
    }

    public OutputUsuario Login(InputLoginUser input)
    {
        var user = _repository!.GetByIdentifier(new InputIdentifierUsuario(input.Email!));

        if (user != null)
        {
            if (user.Senha == input.Senha)
                return FromEntityToOutput(user);
            else
                throw new InvalidOperationException("Senha inválida.");
        }

        throw new InvalidOperationException("Email inválido.");
    }

    public bool SendLinkToRedefinePassword(string email)
    {
        var user = _repository!.GetByIdentifier(new InputIdentifierUsuario(email));

        if (user != null)
        {
            string newPassword = Guid.NewGuid().ToString()[..8];
            user.SetProperty(nameof(Usuario.Senha), newPassword);
            bool sent = _email.Send(user.Email!, "ZombieLab - Nova Senha", $"Sua nova senha é: {newPassword}");
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
}