namespace ClassLibrary
{
        public class CompanyRegistrationCondition : ICondition<UserRequest>
    {
        /// <summary>
        /// Se verifica una igualdad entre el estado del pedido y el condicional inicial.
        /// </summary>
        /// <param name="request">Pedido del usuario.</param>
        /// <returns>Booleano que depende de la igualdad.</returns>
        public bool IsSatisfied(UserRequest request)
        {
            return StateEnum.AwaitingForCompanyRegistration.Equals(request.State);
        }
    }
}
