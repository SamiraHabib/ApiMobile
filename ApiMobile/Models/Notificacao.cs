﻿namespace ApiMobile.Models
{
    public class Notificacao
    {
        public int IdNotificacao { get; set; }
        public int IdRotina { get; set; }
        public int IdExercicio { get; set; }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
        public DateTime Hora { get; set; }
        public bool? Enviado { get; set; }

        public Rotina? Rotina { get; set; }
        public Exercicio? Exercicio { get; set; }
    }
}