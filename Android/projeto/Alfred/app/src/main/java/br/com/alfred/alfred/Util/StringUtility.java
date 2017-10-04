package br.com.alfred.alfred.Util;

import android.widget.EditText;

/**
 * Created by Yuri Developer on 01/10/2017.
 */

public class StringUtility {

    public static final int VERSAO = 4;
    public static final String TABELA_EVENTO = "Evento";
    public static final String TABELA_CHECKLIST = "Checklist";
    public static final String DATABASE = "alfred.db";

    public static boolean isValid(EditText editText){
        if(editText.getText().length() > 0){
            return true;
        }
        return false;
    }
}
