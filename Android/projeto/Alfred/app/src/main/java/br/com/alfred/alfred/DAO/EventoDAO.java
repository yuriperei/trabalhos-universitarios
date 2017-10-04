package br.com.alfred.alfred.DAO;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import java.util.ArrayList;
import java.util.List;

import br.com.alfred.alfred.Model.Evento;
import br.com.alfred.alfred.Util.StringUtility;

/**
 * Created by Yuri Developer on 26/09/2017.
 */

public class EventoDAO extends SQLiteOpenHelper{

    private ChecklistDAO checklistDao;

    public EventoDAO(Context context){
        super(context, StringUtility.DATABASE, null, StringUtility.VERSAO);
        checklistDao = new ChecklistDAO(context);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        String ddl = "CREATE TABLE " + StringUtility.TABELA_EVENTO + "( "
                + "EVENTO_ID integer primary key autoincrement, "
                + "nome TEXT, data TEXT, descricao TEXT, local TEXT, horaInicio TEXT, horaFinal TEXT); ";

        String ddlCheck = "CREATE TABLE " + StringUtility.TABELA_CHECKLIST + " ( "
                + "CHECKLIST_ID integer primary key autoincrement, "
                + "nome TEXT, data TEXT, hora TEXT, feito Integer, codEvento integer);"
                + "foreign key (codEvento) REFERENCES " + StringUtility.TABELA_EVENTO + " (EVENTO_ID);";

        db.execSQL(ddl);
        db.execSQL(ddlCheck);
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        db.execSQL("DROP TABLE IF EXISTS " + StringUtility.TABELA_EVENTO);
        db.execSQL("DROP TABLE IF EXISTS " + StringUtility.TABELA_CHECKLIST);

        onCreate(db);
    }

    public boolean create(Evento evento){
        ContentValues values = new ContentValues();
        values.put("nome", evento.getNome());
        values.put("data", evento.getData());
        values.put("descricao", evento.getDescricao());
        values.put("local", evento.getLocal());
        values.put("horaInicio", evento.getHoraInicio());
        values.put("horaFinal", evento.getHoraFinal());

        SQLiteDatabase db = this.getWritableDatabase();

        boolean isCreate = getWritableDatabase().insert(StringUtility.TABELA_EVENTO, null, values) > 0;
        db.close();

        return isCreate;
    }

    public boolean update(Evento evento){
        ContentValues values = new ContentValues();
        values.put("nome", evento.getNome());
        values.put("data", evento.getData());
        values.put("descricao", evento.getDescricao());
        values.put("local", evento.getLocal());
        values.put("horaInicio", evento.getHoraInicio());
        values.put("horaFinal", evento.getHoraFinal());


        SQLiteDatabase db = this.getWritableDatabase();

        boolean isUpdate = getWritableDatabase().update(StringUtility.TABELA_EVENTO, values, "evento_id=?", new String[]{""+evento.getId()}) > 0;
        db.close();

        return isUpdate;
    }

    public boolean delete(int eventoId){
        boolean isValid = checklistDao.getChecklists(eventoId).size() == 0;
        boolean isDelete = false;

        if(isValid){
            SQLiteDatabase db = this.getWritableDatabase();

            isDelete = getWritableDatabase().delete(StringUtility.TABELA_EVENTO, "evento_id=?", new String[]{""+eventoId}) > 0;
            db.close();
        }

        return isDelete;
    }

    public List<Evento> getEventos(){
        Cursor cursor = getReadableDatabase().query(StringUtility.TABELA_EVENTO, null,null,null,null,null,"nome");
        List<Evento> eventos = new ArrayList<>();
        while (cursor.moveToNext()){
            Evento evento = new Evento();
            evento.setId(cursor.getInt(0));
            evento.setNome(cursor.getString(1));
            evento.setData(cursor.getString(2));
            evento.setDescricao(cursor.getString(3));
            evento.setLocal(cursor.getString(4));
            evento.setHoraInicio(cursor.getString(5));
            evento.setHoraFinal(cursor.getString(6));
            eventos.add(evento);
        }
        cursor.close();
        return eventos;
    }
}
