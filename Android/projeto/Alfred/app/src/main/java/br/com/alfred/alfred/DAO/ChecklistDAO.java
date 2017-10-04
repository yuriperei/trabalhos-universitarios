package br.com.alfred.alfred.DAO;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.util.Log;

import java.util.ArrayList;
import java.util.List;

import br.com.alfred.alfred.Model.Checklist;
import br.com.alfred.alfred.Util.StringUtility;

/**
 * Created by Yuri Developer on 26/09/2017.
 */

public class ChecklistDAO extends SQLiteOpenHelper{

    public ChecklistDAO(Context context){
        super(context, StringUtility.DATABASE, null, StringUtility.VERSAO);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
//        String ddlCheck = "CREATE TABLE " + StringUtility.TABELA_CHECKLIST + " ( "
//                + "CHECKLIST_ID integer primary key autoincrement, "
//                + "nome TEXT, data TEXT, hora TEXT";
//
//        String ddl = "CREATE TABLE " + StringUtility.TABELA_CHECKLIST + "( "
//                + "EVENTO_ID integer primary key autoincrement, "
//                + "nome TEXT, data TEXT, descricao TEXT, local TEXT, horaInicio TEXT, horaFinal TEXT, cod_checklist integer); "
//                + "foreign key (cod_checklist) REFERENCES  "+StringUtility.TABELA_CHECKLIST+" (CHECKLIST_ID);";
//
//        db.execSQL(ddlCheck);
//        db.execSQL(ddl);
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
//        db.execSQL("DROP TABLE IF EXISTS " + StringUtility.TABELA_EVENTO);
//        db.execSQL("DROP TABLE IF EXISTS " + StringUtility.TABELA_CHECKLIST);

//        onCreate(db);
    }

    public boolean create(Checklist checklist){
        ContentValues values = new ContentValues();
        values.put("nome", checklist.getNome());
        values.put("data", checklist.getData());
        values.put("hora", checklist.getHora());
        values.put("feito", checklist.getFeito());
        values.put("codEvento", checklist.getCodEvento());

        SQLiteDatabase db = this.getWritableDatabase();

        boolean isCreate = getWritableDatabase().insert(StringUtility.TABELA_CHECKLIST, null, values) > 0;
        db.close();

        return isCreate;
    }

    public boolean update(Checklist checklist){
        ContentValues values = new ContentValues();
        values.put("nome", checklist.getNome());
        values.put("data", checklist.getData());
        values.put("hora", checklist.getHora());
        values.put("feito", checklist.getFeito());
        values.put("codEvento", checklist.getCodEvento());

        SQLiteDatabase db = this.getWritableDatabase();

        boolean isUpdate = getWritableDatabase().update(StringUtility.TABELA_CHECKLIST, values, "CHECKLIST_ID=?", new String[]{""+checklist.getId()}) > 0;
        db.close();

        return true;
    }

    public boolean delete(int checklistId){
        SQLiteDatabase db = this.getWritableDatabase();

        boolean isUpdate = getWritableDatabase().delete(StringUtility.TABELA_CHECKLIST, "CHECKLIST_ID=?", new String[]{""+checklistId}) > 0;
        db.close();

        return isUpdate;
    }

//    public List<Checklist> getChecklists(int idEvento){
//        String query = "SELECT checklist_id, nome, data, hora, feito, codEvento FROM " + StringUtility.TABELA_CHECKLIST + " WHERE codEvento = " + idEvento + " ORDER BY Nome";
//        Cursor cursor = getReadableDatabase().rawQuery(query, null);
//        getReadableDatabase().q
//        List<Checklist> checklists = new ArrayList<>();
//        while (cursor.moveToNext()){
//            Checklist checklist = new Checklist();
//            checklist.setId(cursor.getInt(0));
//            checklist.setNome(cursor.getString(1));
//            checklist.setData(cursor.getString(2));
//            checklist.setHora(cursor.getString(3));
//            checklist.setFeito(cursor.getInt(4));
//            checklist.setCodEvento(cursor.getInt(5));
//            checklists.add(checklist);
//        }
//        cursor.close();
//        return checklists;
//    }

    public List<Checklist> getChecklists(int idEvento){
        Log.d("ID_EVENTO_DAO", String.valueOf(idEvento));
        Cursor cursor = getReadableDatabase().query(StringUtility.TABELA_CHECKLIST, null, "codEvento=?",new String[]{String.valueOf(idEvento)},null,null,"nome");
        List<Checklist> checklists = new ArrayList<>();
        while (cursor.moveToNext()){
            Log.d("CHECKLIST NOME:", cursor.getString(1));
            Checklist checklist = new Checklist();
            checklist.setId(cursor.getInt(0));
            checklist.setNome(cursor.getString(1));
            checklist.setData(cursor.getString(2));
            checklist.setHora(cursor.getString(3));
            checklist.setFeito(cursor.getInt(4));
            checklist.setCodEvento(cursor.getInt(5));
            checklists.add(checklist);
        }
        cursor.close();
        return checklists;
    }

    public List<Checklist> getChecklists(){
        Cursor cursor = getReadableDatabase().query(StringUtility.TABELA_CHECKLIST, null,null,null,null,null,"nome");
        List<Checklist> checklists = new ArrayList<>();
        while (cursor.moveToNext()){
            Checklist checklist = new Checklist();
            checklist.setId(cursor.getInt(0));
            checklist.setNome(cursor.getString(1));
            checklist.setData(cursor.getString(2));
            checklist.setHora(cursor.getString(3));
            checklist.setFeito(cursor.getInt(4));
            checklist.setCodEvento(cursor.getInt(5));
            checklists.add(checklist);
        }
        cursor.close();
        return checklists;
    }
}
