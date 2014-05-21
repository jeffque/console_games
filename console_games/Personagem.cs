using System;

namespace console_games {
	public class Personagem {
		int hp, hp_tot;
		int atk;
		int def;
		bool alive;
		bool defending;
		string name;

		public Personagem (int hp, int atk, int def, string name) {
			this.hp_tot = this.hp = hp;
			this.atk = atk;
			this.def = def;
			this.name = name;

			alive = true;
			defending = false;
		}

		public double porcento_vida() {
			return (100.0 * hp) / hp_tot;
		}

		public int atacar(Personagem inimigo) {
			return inimigo.receber_dano (atk/(defending? 2: 1));
		}

		// Mínimo de dano recebido é 1
		protected int receber_dano(int atk) {
			int dano_base;

			dano_base = atk - (this.def * (defending? 2: 1));

			if (dano_base <= 0) {
				dano_base = 1;
			}

			hp -= dano_base;

			if (hp <= 0) {
				hp = 0;
				alive = false;
			}

			return dano_base;
		}

		public bool is_alive() {
			return alive;
		}

		public void novo_turno() {
			defending = false;
		}

		public void set_defending() {
			defending = true;
		}

		public string get_name() {
			return name;
		}
	}
}

