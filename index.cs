using System;
    class Program{
        static void Main(){
          
        }
    }
    class Aluno{
        private string nome;
        private double nota;
        private Data Nascimento;
        private Data Cadastro;

    }
    class Data{
        private int dia;
        private int mes;
        private int ano;

        public void setDia(int dia){ //set é ára colocar o dominio
        if(dia > 0 && dia <= 31){
            this.dia = dia;
        }
        }
        public void setMes(int mes) {
            if(mes > 0 && mes <= 12){
                this.mes = mes;
            }
        }
        public void setAno(int ano){
            this.ano = ano;
        }
        public void getDia(){  //levar a variavel p main
            return dia;
        }
        public void getMes(){
            return mes;
        }
        public void getAno(){
            return ano;
        }
        
    }