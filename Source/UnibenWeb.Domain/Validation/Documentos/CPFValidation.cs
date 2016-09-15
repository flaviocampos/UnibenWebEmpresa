namespace UnibenWeb.Domain.Validation.Documentos
{
    public class CPFValidation
    {
        public static bool Validar(string cpfVerificar)
        {
            cpfVerificar = cpfVerificar.Trim();
            cpfVerificar = cpfVerificar.Replace(".", "").Replace("-", "");

            if (cpfVerificar.Length != 11 || cpfVerificar == "00000000000" || cpfVerificar == "11111111111" || cpfVerificar == "22222222222" || cpfVerificar == "33333333333" ||
    cpfVerificar == "44444444444" || cpfVerificar == "55555555555" || cpfVerificar == "66666666666" || cpfVerificar == "77777777777" ||
    cpfVerificar == "88888888888" || cpfVerificar == "99999999999")
                return false;

            var mt1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var mt2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            if (cpfVerificar.Length != 11)
            {
                return false;
            }
            var tempCpf = cpfVerificar.Substring(0, 9);

            var soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * (mt1[i]);
            }
            var resto = soma % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            var digito = resto.ToString();
            tempCpf = tempCpf + digito;
            int soma2 = 0;

            for (int i = 0; i < 10; i++)
            {
                soma2 += int.Parse(tempCpf[i].ToString()) * mt2[i];
            }

            resto = soma2 % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = digito + resto;
            return cpfVerificar.EndsWith(digito);
        }
    }
}
