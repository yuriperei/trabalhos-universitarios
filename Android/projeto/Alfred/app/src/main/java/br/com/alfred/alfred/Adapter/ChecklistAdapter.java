package br.com.alfred.alfred.Adapter;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import java.util.List;

import br.com.alfred.alfred.Model.Checklist;
import br.com.alfred.alfred.R;

/**
 * Created by Yuri Developer on 30/09/2017.
 */

public class ChecklistAdapter extends BaseAdapter {

    private List<Checklist> list;
    private Context context;

    public ChecklistAdapter(Context context, List<Checklist> list){
        this.context = context;
        this.list = list;
    }

    @Override
    public int getCount() {
        return list.size();
    }

    @Override
    public Object getItem(int i) {
        return list.get(i);
    }

    @Override
    public long getItemId(int i) {
        return 0;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        if(convertView == null){
            convertView = LayoutInflater.from(context).inflate(R.layout.checklist_adaptercell, null);
        }
        Checklist checklist = list.get(position);
        TextView txtNome = (TextView) convertView.findViewById(R.id.txtNome);
        TextView txtData = (TextView) convertView.findViewById(R.id.txtData);
        TextView txtHorario = (TextView) convertView.findViewById(R.id.txtHorario);
        TextView txtFeito = (TextView) convertView.findViewById(R.id.txtFeito);

        txtNome.setText(checklist.getNome());
        txtData.setText("Data: " + checklist.getData());
        txtHorario.setText("Horario: "+checklist.getHora());
        txtFeito.setText("Concluído: " + (checklist.getFeito() != 0 ? "Sim" : "Não"));

        return convertView;
    }
}
