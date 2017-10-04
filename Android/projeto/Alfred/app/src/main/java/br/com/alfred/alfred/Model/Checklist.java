package br.com.alfred.alfred.Model;

import java.io.Serializable;

/**
 * Created by Yuri Developer on 01/10/2017.
 */

public class Checklist implements Serializable{

    private int id;
    private String nome;
    private String data;
    private String hora;
    private int codEvento;
    private int feito;

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public String getData() {
        return data;
    }

    public void setData(String data) {
        this.data = data;
    }

    public String getHora() {
        return hora;
    }

    public void setHora(String hora) {
        this.hora = hora;
    }

    public int getCodEvento() {
        return codEvento;
    }

    public void setCodEvento(int codEvento) {
        this.codEvento = codEvento;
    }

    public int getFeito() {
        return feito;
    }

    public void setFeito(int feito) {
        this.feito = feito;
    }
}
