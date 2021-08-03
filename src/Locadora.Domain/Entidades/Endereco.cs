﻿using System;


public class Endereco
{
    public Guid Id { get; set; }
	public string Logradouro { get; set; }
	public string Bairro { get; set; }
	public string Uf { get; set; }
	public string Complemento { get; set; }
	public string Cep { get; set; }
	public int Numero { get; set; }
	public string Cidade { get; set; }
	public string Estado { get; set;}

    public Endereco(Guid id, string logradouro, string bairro, string uf, string complemento, string cep, int numero, string cidade, string estado)
    {
        Id = id;
        Logradouro = logradouro;
        Bairro = bairro;
        Uf = uf;
        Complemento = complemento;
        Cep = cep;
        Numero = numero;
        Cidade = cidade;
        Estado = estado;
    }
}
