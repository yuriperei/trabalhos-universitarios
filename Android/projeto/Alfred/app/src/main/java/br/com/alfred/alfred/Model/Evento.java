package br.com.alfred.alfred.Model;

import java.io.Serializable;

/**
 * Created by Yuri Developer on 26/09/2017.
 */

public class Evento implements Serializable{
    private int id;
    private String nome;
    private String descricao;
    private String horaInicio;
    private String horaFinal;
    private String local;
    private String data;
    //private ArrayList<Checklist> checklists;

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

    public String getDescricao() {
        return descricao;
    }

    public void setDescricao(String descricao) {
        this.descricao = descricao;
    }

    public String getHoraInicio() {
        return horaInicio;
    }

    public void setHoraInicio(String horaInicio) {
        this.horaInicio = horaInicio;
    }

    public String getHoraFinal() {
        return horaFinal;
    }

    public void setHoraFinal(String horaFinal) {
        this.horaFinal = horaFinal;
    }

    public String getLocal() {
        return local;
    }

    public void setLocal(String local) {
        this.local = local;
    }

    @Override
    public String toString() {
        return super.toString();
    }

    //    public ArrayList<Checklist> getChecklists() {
//        return checklists;
//    }
//
//    public void setChecklists(ArrayList<Checklist> checklists) {
//        this.checklists = checklists;
//    }
}
