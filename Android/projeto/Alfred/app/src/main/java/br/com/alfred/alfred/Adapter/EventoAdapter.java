package br.com.alfred.alfred.Adapter;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import java.util.List;

import br.com.alfred.alfred.Model.Evento;
import br.com.alfred.alfred.R;

/**
 * Created by Yuri Developer on 30/09/2017.
 */

public class EventoAdapter extends BaseAdapter {

    private List<Evento> list;
    private Context context;

    public EventoAdapter(Context context, List<Evento> list){
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
            convertView = LayoutInflater.from(context).inflate(R.layout.evento_adaptercell, null);
        }
        Evento evento = list.get(position);
        TextView txtNome = (TextView) convertView.findViewById(R.id.txtNome);
        TextView txtData = (TextView) convertView.findViewById(R.id.txtData);
        TextView txtHorario = (TextView) convertView.findViewById(R.id.txtHorario);
        TextView txtLocal = (TextView) convertView.findViewById(R.id.txtLocal);

        txtNome.setText(evento.getNome());
        txtData.setText("Data: " + evento.getData());
        txtHorario.setText("Horario: "+evento.getHoraInicio() + " às " + evento.getHoraFinal());
        txtLocal.setText("Local: " + evento.getLocal());

        return convertView;
    }
}
