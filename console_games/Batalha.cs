using System;

namespace console_games {
	public class Batalha: Game {
		Personagem[] personas;
		protected int max_attr = 10;
		protected int sum_attr = 15;

		protected string[] attr_names = new string[3] { "Ataque", "Defesa", "HP" };

		public Batalha (): base() {
		}

		protected override int get_n_jogadores() {
			int n;
			do {
				Console.WriteLine ("Quantos jogadores? ( >= 2)");
				n = Convert.ToInt32(Console.ReadLine());
			} while (n < 2);
			return 2;
		}

		protected override void init_game() {
			bool jogador_invalido;
			personas = new Personagem[n_jogadores];
			int[] attr = new int[3];
			int sum;

			for (int i = 0; i < n_jogadores; i++) {
				do {
					Console.WriteLine (players [i] + ", crie seu personagem:");
					Console.WriteLine ("\tSoma de atributos: " + sum_attr);
					Console.WriteLine ("\tMáximo de atributo: " + max_attr);

					jogador_invalido = false;
					sum = 0;
					for (int j = 0; j < 3; j++) {
						Console.WriteLine(attr_names[j]);
						attr[j] = Convert.ToInt32(Console.ReadLine());

						sum += attr[j];
						if (attr[j] > max_attr) {
							jogador_invalido = true;
						}
					}

					if (sum != sum_attr) {
						jogador_invalido = true;
					}

				} while (jogador_invalido);

				personas [i] = new Personagem (attr [2], attr [0], attr [1], players [i]);
			}
		}
	}
}

