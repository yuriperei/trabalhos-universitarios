package br.com.alfred.alfred.Controller;

import android.content.Context;

import java.util.List;

import br.com.alfred.alfred.DAO.ChecklistDAO;
import br.com.alfred.alfred.Model.Checklist;

/**
 * Created by Yuri Developer on 26/09/2017.
 */

public class ChecklistController {

    private ChecklistDAO dao;

    public ChecklistController(Context context){
        this.dao = new ChecklistDAO(context);
    }

    public boolean create(Checklist Checklist){
        return this.dao.create(Checklist);
    }

    public List<Checklist> getCheckLists(int idEvento){
        return this.dao.getChecklists(idEvento);
    }

    public boolean update(Checklist Checklist){
        return this.dao.update(Checklist);
    }

    public boolean delete(int ChecklistId){
        return this.dao.delete(ChecklistId);
    }
}
