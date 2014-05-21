using System;
using System.Reflection;
using System.Collections.Generic;

namespace console_games {
	class console_games {
		private static string[] game_names;
		private static Game[] game_list;

		public static void Main (string[] args) {
			List<Type> l_game_types = new List<Type>();
			Type tgame = Type.GetType ("console_games.Game", true);

			foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies()) {
				foreach (Type t in asm.GetTypes()) {
					if (t.IsSubclassOf (tgame)) {
						l_game_types.Add (t);
					}
				}
			}

			game_names = new string[l_game_types.Count];
			game_list = new Game[l_game_types.Count];

			int i = 0;
			foreach (Type game in l_game_types) {
				game_names[i] = game.FullName.Split(new char[]{'.'})[1];
				game_list[i] = Activator.CreateInstance (game) as Game;
				i++;
			}
			Console.WriteLine ("Hello World!");

			int opt;
			do {
				Console.WriteLine("Escolha o jogo desejado");
				list_games();
				opt = Convert.ToInt32(Console.ReadLine());
				do_play(opt);
			} while (opt >= 0);
		}

		public static void list_games() {
			int i = 0;
			foreach (string game_name in game_names) {
				Console.WriteLine("\t" + i + " -> " + game_name);
				i++;
			}
			Console.WriteLine ("\t-1 -> sair");
		}

		public static void do_play(int opt) {
			if (opt < 0 || opt >= game_names.Length) {
				return;
			}
			Game g = game_list [opt];

			g.prepare_game ();
			g.play_game ();
			g.post_game ();

			if (g.get_winner () != null) {
				Console.WriteLine ("Parabéns, " + g.get_winner () + ", você venceu!");
			}
			Console.WriteLine ("\n-----\n\n");
		}
	}
}
