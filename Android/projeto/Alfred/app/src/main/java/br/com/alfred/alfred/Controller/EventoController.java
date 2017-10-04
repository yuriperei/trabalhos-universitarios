package br.com.alfred.alfred.Controller;

import android.content.Context;

import java.util.List;

import br.com.alfred.alfred.DAO.EventoDAO;
import br.com.alfred.alfred.Model.Evento;

/**
 * Created by Yuri Developer on 26/09/2017.
 */

public class EventoController{

    private EventoDAO dao;

    public EventoController(Context context){
        this.dao = new EventoDAO(context);
    }

    public boolean create(Evento evento){
        return this.dao.create(evento);
    }

//    public int getCount(){
//        return 0;
//    }

    public List<Evento> getEventos(){
        return this.dao.getEventos();
    }

//    public Evento getById(int eventoId){
//        return null;
//    }

    public boolean update(Evento evento){
        return this.dao.update(evento);
    }

    public boolean delete(int eventoId){
        return this.dao.delete(eventoId);
    }
}
