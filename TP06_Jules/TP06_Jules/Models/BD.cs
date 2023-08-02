using System.Data.SqlClient;

using Dapper;
using System.Collections.Generic;

namespace TP06_Jules.Models;

public static class BD
{
    public static string _connectionString = @"Server=COMPUTADORALULI\SQLEXPRESS01;
    Database=Elecciones2023;Trusted_Connection=True;";

    public static void AgregarCandidato(Candidato can)
    {
        string sql = "INSERT INTO Candidato(IdPartido, Apellido, Nombre, FechaNacimiento, Foto, Postulacion) VALUES(@cIdPartido, @cApellido, @cNombre, @cFechaNacimiento, @cFoto, @cPostulacion)";
        using (SqlConnection BD = new SqlConnection(_connectionString))
        {
            BD.Execute(sql, new {cIdPartido = can.IdPartido, cApellido = can.Apellido,  cNombre = can.Nombre, cFechaNacimiento = can.FechaNacimiento, cFoto = can.Foto, cPostulacion = can.Postulacion});
        }
    }

    public static void EliminarCandidato(int idCandidato)
    {
        string sql = "DELETE FROM Candidato WHERE idCandidato = @cIdCandidato)";
        using (SqlConnection BD = new SqlConnection(_connectionString))
        {
            BD.Execute(sql, new { cIdCandidato = idCandidato});
        }
    }
    public static Partido VerInfoPartido(int idPartido)
    {
        Partido partido= null; 
        using (SqlConnection BD = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Partido WHERE idPartido = @Id";
            partido= BD.QueryFirstOrDefault<Partido>(sql, new {Id = idPartido});
        }
        return partido;
    }
    public static Candidato VerInfoCandidato(int idCandidato)
    {
        Candidato candidato= null; 
        using (SqlConnection BD = new SqlConnection(_connectionString))
        {        
            string sql = "SELECT * FROM Candidato WHERE idCandidato = @cIdCandidato";
            candidato= BD.QueryFirstOrDefault<Candidato>(sql, new { cIdCandidato= idCandidato});
        }
        return candidato;
    }

    public static List<Partido> ListarPartidos()
    {
        List<Partido> ListadoPartidos = new List<Partido>();
        using (SqlConnection BD = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Partido";
            ListadoPartidos= BD.Query<Partido>(sql).ToList();
        }
        return ListadoPartidos;
    }

    public static List<Candidato> ListarCandidatos(int idPartido)
    {
        List<Candidato> ListarCandidatos = null; 
        using (SqlConnection BD = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Candidato WHERE idPartido = @pIdPartido";
            ListarCandidatos= BD.Query<Candidato>(sql, new{pIdPartido = idPartido}).ToList();
        }
        return ListarCandidatos;
    }
}
