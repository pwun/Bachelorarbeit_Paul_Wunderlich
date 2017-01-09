#include<stdio.h>

int main() {
	printf("Programmstart\n");
  prim2(100);
	return 0;
}

void prim2(int MAX_ZAHL){
  int  Proband;   /* aktuelle Zahl, die geprüft werden soll */
  int  Divisor;   /* aktueller Divisor */
  char Primzahl;  /* Marke für Primzahl */
  printf("Primzahlen zwischen 1 und %d:\n", MAX_ZAHL);

    /* Schleife für alle zu prüfenden Zahlen */
    for(Proband=1; Proband<=MAX_ZAHL; Proband++) {

        Primzahl = 1;   /* Annahme: Es ist eine Primzahl */

        /* Schleife für alle Divisoren */
        for(Divisor=2; Divisor<Proband; Divisor++) {

            /* Wenn kein Rest bei Division: keine Primzahl */
            if(Proband%Divisor==0) Primzahl = 0;
        }

        /* Ggf. Primzahl ausgeben */
        if(Primzahl) printf("%8d", Proband);
    }
    printf("\n");   /* Zeilenvorschub */
}

int ggT(int a, int b){
	printf("ggT fuer: %d/%d\n", a, b);
	int teiler;
	if(a>b){
		teiler = a;
	}else{
		teiler = b;
	}
	while(a%teiler != 0 || b%teiler != 0 || a/teiler==0 || b/teiler==0){
		teiler = teiler -1;
	}
	printf("teiler: %d\n", teiler);
	a = a/teiler;
	b = b/teiler;
	printf("ergebnis: %d/%d\n", a, b);
	return teiler;
}
