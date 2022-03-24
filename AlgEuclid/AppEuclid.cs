using System;
using System.Drawing;
using System.Windows.Forms;

namespace AlgEuclid {
    public partial class euclidForm : Form {
        public euclidForm() {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e) {
            if (firstNum.Value == 0 || secondNum.Value == 0) {
                MessageBox.Show("Agrs are zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int first = Convert.ToInt32(firstNum.Value);
            int second = Convert.ToInt32(secondNum.Value);

            if (first > 0 && second < 0) {
                int t = first;
                first = second;
                second = t;
            }

            //if (first < 0 && second < 0) {
            //    first *= -1;
            //    second *= -1;
            //}

            #region Euclid Second Method

            euclidTablRec.Rows.Clear();

            int cnterRow = euclidTablRec.RowCount++; ;

            if (cnterRow == 0) {
                euclidTablRec[0, cnterRow].Value = cnterRow;

                euclidTablRec[1, cnterRow].Style.BackColor = Color.LightGray;

                euclidTablRec[2, cnterRow].Value = 1; // u_i
                euclidTablRec[3, cnterRow].Value = 0; // v_i
                euclidTablRec[4, cnterRow].Value = first; // r_i

                euclidTablRec[5, cnterRow].Value = 0; // u_i+1
                euclidTablRec[6, cnterRow].Value = 1; // v_i+1
                euclidTablRec[7, cnterRow].Value = second; //r_i+1
            }

            bool flag = false;
            while (Convert.ToInt32(euclidTablRec[7, cnterRow].Value) != 0) {
                cnterRow = euclidTablRec.RowCount++;
                euclidTablRec[0, cnterRow].Value = cnterRow;

                euclidTablRec[1, cnterRow].Value = Convert.ToInt32(euclidTablRec[4, cnterRow - 1].Value) / Convert.ToInt32(euclidTablRec[7, cnterRow - 1].Value);

                if (first < 0 && second > 0) {
                    if (!flag) 
                        euclidTablRec[1, cnterRow].Value = Convert.ToInt32(euclidTablRec[1, cnterRow].Value) - 1;
                }

                euclidTablRec[2, cnterRow].Value = euclidTablRec[5, cnterRow - 1].Value;
                euclidTablRec[3, cnterRow].Value = euclidTablRec[6, cnterRow - 1].Value;
                euclidTablRec[4, cnterRow].Value = euclidTablRec[7, cnterRow - 1].Value;

                euclidTablRec[7, cnterRow].Value = Convert.ToInt32(euclidTablRec[4, cnterRow - 1].Value) - Convert.ToInt32(euclidTablRec[1, cnterRow].Value) * Convert.ToInt32(euclidTablRec[4, cnterRow].Value);
                if (Convert.ToInt32(euclidTablRec[7, cnterRow].Value) != 0) {
                    euclidTablRec[5, cnterRow].Value = Convert.ToInt32(euclidTablRec[2, cnterRow - 1].Value) - Convert.ToInt32(euclidTablRec[1, cnterRow].Value) * Convert.ToInt32(euclidTablRec[2, cnterRow].Value);
                    euclidTablRec[6, cnterRow].Value = Convert.ToInt32(euclidTablRec[3, cnterRow - 1].Value) - Convert.ToInt32(euclidTablRec[1, cnterRow].Value) * Convert.ToInt32(euclidTablRec[3, cnterRow].Value);
                } else {
                    euclidTablRec[5, cnterRow].Style.BackColor = Color.LightGray;
                    euclidTablRec[6, cnterRow].Style.BackColor = Color.LightGray;
                }

                flag = true;
            }

            euclidTablRec[2, cnterRow].Style.BackColor = Color.LightPink;
            euclidTablRec[3, cnterRow].Style.BackColor = Color.LightPink;
            euclidTablRec[4, cnterRow].Style.BackColor = Color.Yellow;
            euclidTablRec[7, cnterRow].Style.BackColor = Color.LightGreen;

            #endregion

        }
    }
}
