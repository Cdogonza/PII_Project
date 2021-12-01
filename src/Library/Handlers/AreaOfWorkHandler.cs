using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.VisualBasic;

namespace ClassLibrary
{
    /// <summary>
    /// Este handler implementa el patrón Chain of Responsability y es el encargado de manejar los comandos /rubros, /listar_rubros y /agregar_rubros
    /// Permite a las companias agregar rubros nuevos y listarlos, y los emprendedores a listar los rubros existentes en el sistema 
    /// </summary>
    public class AreaOfWorkHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AreaOfWorkHandler"/>.
        /// Procesa los mensajes /rubros, /listar_rubros, /agregar_rubros
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public AreaOfWorkHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/rubros", "/listar_rubros", "/agregar_rubros" };
        }

        /// <summary>
        /// Este metodo es el encargado de procesar el mensaje que le llega de telegram y enviar una respuesta
        /// </summary>
        /// <param name="message"> El mensaje que llega para procesar</param>
        /// <param name="response">La respuesta del mensaje procesado </param>
        /// <returns></returns>
        protected override bool InternalHandle(IMessage message, out string response)
        {

            if (!Singleton<TelegramUserData>.Instance.userdata.ContainsKey(message.UserId))
            {
                Singleton<TelegramUserData>.Instance.userdata.Add(message.UserId, new Collection<string>());
            }

            if (message.Text.ToLower().Equals("/rubros"))
            {
                if (Singleton<DataManager>.Instance.GetEntrepreneur(message.UserId) != null)
                {
                    Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                    response = "Usted puede ver la lista de rubros /listar_rubros";
                    return true;
                }

                if (Singleton<DataManager>.Instance.GetCompany(message.UserId) != null)
                {
                    Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                    response = "Usted puede ver la lista de rubros /listar_rubros\no agregar rubros al sitema /agregar_rubros";
                    return true;
                }
            }
            if (Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count >= 1)
            {
                if (Singleton<TelegramUserData>.Instance.userdata[message.UserId][0].ToLower().Contains("/rubros"))
                {
                    if (message.Text.ToLower().Equals("/listar_rubros"))
                    {
                        Singleton<TelegramUserData>.Instance.userdata.Remove(message.UserId);
                        response = Singleton<DataManager>.Instance.GetTextToPrintAreaOfWork();
                        return true;
                    }

                    if (message.Text.ToLower().Equals("/agregar_rubros"))
                    {
                        if (Singleton<DataManager>.Instance.GetCompany(message.UserId) != null)
                        {
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                            response = "Ingrese el nombre del rubro";
                            return true;
                        }
                        else
                        {
                            response = "No tiene privilegios suficientes para agregar rubros, solo las empresas pueden realizar esta acción";
                            return true;
                        }
                    }

                    if (Singleton<TelegramUserData>.Instance.userdata[message.UserId][1].ToLower().Contains("/agregar_rubros"))
                    {
                        if (!message.Text.ToUpper().Equals("SI") && !message.Text.ToUpper().Equals("NO"))
                        {
                            Singleton<TelegramUserData>.Instance.userdata[message.UserId].Add(message.Text);
                            response = "Desea ingresar otro Rubro? Si/No";
                            return true;
                        }
                        if (message.Text.ToUpper().Equals("SI"))
                        {
                            response = "Ingrese el nombre del nuevo Rubro";
                            return true;
                        }
                        else if (message.Text.ToUpper().Equals("NO"))
                        {
                            StringBuilder responsetemp = new StringBuilder();
                            responsetemp.Append("Se agregaron los siguientes rubros: \n");
                            for (int i = 2; i < Singleton<TelegramUserData>.Instance.userdata[message.UserId].Count; i++)
                            {
                                Singleton<DataManager>.Instance.AddAreaOfWork(Singleton<TelegramUserData>.Instance.userdata[message.UserId][i]);
                                responsetemp.Append($"{Singleton<TelegramUserData>.Instance.userdata[message.UserId][i]}\n");
                            }
                            Singleton<TelegramUserData>.Instance.userdata.Remove(message.UserId);

                            response = $"{responsetemp}";
                            return true;
                        }
                    }
                }
            }
            response = String.Empty;
            return false;
        }
    }
}