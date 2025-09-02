import { Performer } from "../../Library/Performer";

export class Gravity {

    performer: Performer = new Performer();
    /*  !!! DELETE AFTER

    		[0]	-5448.34815324	object {double}
		[1]	-4463.93698421	object {double}
		[2]	0	object {double}
-		output	{object[3]}	object[]
		[0]	0.0062231496943680161	object {double}
		[1]	0.0050988376640921027	object {double}
		[2]	-2.8664480643872004E-08	object {double}

    */
    constructor() {

        this.enlarge(this.R, 3);
        this.enlarge(this.C, 700);
        this.enlarge(this.S, 700);
        this.enlarge(this.HP, 37);
        this.enlarge(this.CO, 37);
        this.enlarge(this.SI, 37);
        this.enlarge(this.AR, 37);
        this.enlarge(this.CF, 37);
        this.enlarge(this.PNK, 37);
        this.enlarge(this.ANAI, 438);
    }
    enlarge(x: number[], n: number): void { this.performer.enlargeNumber(x, n); };
    protected R: number[] = [];

    protected C: number[] = [];

    protected S: number[] = [];

    protected HP: number[] = [];

    protected CO: number[] = [];

    protected SI: number[] = [];

    protected AR: number[] = [];

    protected CF: number[] = [];

    protected PNK: number[] = [];

    protected ANAI: number[] = [];

    protected SK: number[] = [
        1.732050807568877E0, 1.936491673103709E0, 2.091650066335189E0,
        2.218529918662356E0, 2.326813808623286E0, 2.421824596249695E0,
        2.506826616960176E0, 2.583977731709147E0, 2.654784752117980E0,
        2.720344864917320E0, 2.781483843970261E0, 2.838840060634283E0,
        2.892918063839265E0, 2.944124128779573E0, 2.992790634483277E0,
        3.039193256447120E0, 3.083563388216997E0, 3.126097306274296E0,
        3.166963057815222E0, 3.206305722292480E0, 3.244251489527417E0,
        3.280910862053330E0, 3.316381199514726E0, 3.350748761981671E0,
        3.384090366884451E0, 3.416474744628894E0, 3.447963656780269E0,
        3.478612825366963E0, 3.508472710600489E0, 3.537589165949811E0,
        3.566003993231045E0, 3.593755415611321E0, 3.620878482777667E0,
        3.647405419702514E0, 3.673365928240249E0, 3.698787449063569E0
    ];

    protected n0: number = 0;

    protected nk: number = 0;

    protected inp: string[] = ["", "", ""];
    protected inps: string[] = ["x", "y", "z"];
    protected outs: string[] = ["Gx", "Gy", "Gz"];

    protected pos: number = 0;

    ret: number = 0;

    GetN0(): number { return this.n0; }

    SetN0(x: number): void { this.n0 = x; }

    GetNK(): number { return this.nk; }

    SetNK(x: number): void { this.nk = x; }

    GetMUR(): number[] { return this.R; }


    GetCnm(): number[] { return this.C; }



    GetSnm(): number[] { return this.S; }



    protected Forces(X: number, Y: number, Z: number,
        FX: number[], FY: number[], FZ: number[]): void {
        this.ForcesN(this.n0, this.nk, X, Y, Z, FX, FY, FZ);
    }

    protected ForcesN(N0: number, NK: number, X: number, Y: number, Z: number,
        FX: number[], FY: number[], FZ: number[]): void {

        let LOG = false;
        let P20 = 0.0;
        let P30 = 0.0;
        let PN0 = 0.0;
        let A = 0.0;
        let AN = 0.0;
        let FR = 0.0;
        let FF = 0.0;
        let FL = 0.0;
        let R2 = X * X + Y * Y;
        let R3 = 1 / (R2 + Z * Z);
        let R1 = Math.sqrt(R3);
        let N1 = 0;
        let N2 = 0;
        let N3 = 0;
        let N4 = 0;
        let N5 = 0;
        let CK1 = 0;
        let CK2 = 0;
        let J = 0;
        let TG = 0;
        R2 = Math.sqrt(R2);
        let SF = Z * R1;
        this.CF[0] = R2 * R1;
        R2 = 1 / R2;
        this.CO[0] = X * R2;
        this.SI[0] = Y * R2;
        let GR = this.R[0] * R3;
        if (N0 != 0 || NK != 0)
        {
            this.CF[1] = this.CF[0] * this.CF[0];
            this.AR[0] = this.R[1] * R1;
            for (let N = 1; N < N0; N++)
            {
                N3 = N - 1;
                this.AR[N] = this.AR[0] * this.AR[N3];
                A = this.C[N3] * this.AR[N];
                if (N == 1)
                {
                    P20 = Math.sqrt(5) * (1.0 - 1.5 * this.CF[1]);
                    this.PNK[0] = Math.sqrt(15) * this.CF[0] * SF;
                    FR = 3.0 * A * P20;
                    FF = A * this.PNK[0] * Math.sqrt(3);
                }
                else if (N == 2)
                {
                    P30 = Math.sqrt(7) * (1.0 - 2.5 * this.CF[1]) * SF;
                    this.PNK[1] = /*SQ[62]/SQ[23]*/ Math.sqrt(63) / Math.sqrt(24) *
                        this.CF[0] * (4.0 - 5.0 * this.CF[1]);
                    FR += 4 * A * P30;
                    FF += A * this.PNK[1] * Math.sqrt(6); //SQ[5];
                }
                else
                {
                    N1 = N + N3 + 1;
                    N2 = N1 + 2;
                    N4 = N + 1;
                    AN = (N + 1);
                    PN0 = Math.sqrt(N2 + 1) / AN * ( /*SQ[N1]*/
                        Math.sqrt(N1 + 1) * SF * P30 - (N3 + 1) / /*SQ[N1-2]*/ Math.sqrt(N1 - 1) * P20);
                    this.PNK[N3] = Math.sqrt(N2 + 1) / (Math.sqrt(N3 + 1) *
                        Math.sqrt(N4 + 1)) * (Math.sqrt(N1 + 1) * SF *
                            this.PNK[N - 2] - Math.sqrt(N + 1) *
                            Math.sqrt(N - 1) / Math.sqrt(N1 - 1) * this.PNK[N - 3]);
                    FR += (N4 + 1) * A * PN0;
                    FF += A * /*SQ[N]*SQ[N4]/SQ[1]*/ Math.sqrt(N + 1) * Math.sqrt(N4 + 1) / Math.sqrt(2) * this.PNK[N3];
                    P20 = P30;
                    P30 = PN0;

                }

                var j = 0;
            }
            var i = 0;
        }
        if (NK != 0)
        {
            LOG = (NK >= 3);
            A = this.CO[0] + this.CO[0];
            this.CO[1] = A * this.CO[0] - 1;
            this.SI[1] = A * this.SI[0];
            TG = Z * R2;
            if (LOG)
            {
                for (let N = 2; N < this.nk; N++)
                { //2
                    N1 = N - 1;
                    N2 = N - 2;
                    this.CF[N] = this.CF[0] * this.CF[N1];
                    this.CO[N] = A * this.CO[N1] - this.CO[N2];
                    this.SI[N] = A * this.SI[N1] - this.SI[N2];
                } //2
            }
            CK1 = (this.C[35] * this.CO[0] + this.S[35] * this.SI[0]) * this.AR[1];
            CK2 = (this.C[35] * this.SI[0] - this.S[35] * this.CO[0]) * this.AR[1];
            A = this.PNK[0];
            this.PNK[0] = this.SK[1] * this.CF[1];
            FR += CK1 * 3.0 * A;
            FF += CK1 * (this.PNK[0] + this.PNK[0] - TG * A);
            FL += CK2 * A;
            J = 35;
            if (LOG)
            {
                for (let N = 2; N < NK; N++)    //commain
                {                //3
                    J++;
                    N1 = N - 1;
                    N2 = N + N + 1;
                    N3 = N + 1;
                    A = this.PNK[N1];
                    CK1 = (this.C[J] * this.CO[0] + this.S[J] * this.SI[0]) * this.AR[N];
                    CK2 = (this.C[J] * this.SI[0] - this.S[J] * this.CO[0]) * this.AR[N];
                    if (N == 2)
                        this.PNK[1] = /*SQ[6]*/ Math.sqrt(7) * SF * this.PNK[0];
                    else
                        this.PNK[N1] = Math.sqrt(N2 + 2) / (Math.sqrt(N - 1) * Math.sqrt(N + 3)) * (Math.sqrt(N2) *
                            SF * this.PNK[N - 2] - Math.sqrt(N3 + 1) * Math.sqrt(N - 2) / Math.sqrt(N2 - 2) * this.PNK[N - 3]);
                    FR += (N3 + 1) * CK1 * A;
                    FF += CK1 * (this.PNK[N1] */*SQ[N1]*/ Math.sqrt(N1 + 1) */*SQ[N+2]*/ Math.sqrt(N + 3) - TG * A);
                    FL += CK2 * A;
                }
            }//ENDIF //3
            for (let M = 1; M < NK; M++)
            {                      // 4
                J = Math.floor(this.ANAI[1 + M] + 0.5) - 1;
                for (let N = M; N < NK; N++)
                {                       //4.1
                    N1 = N - M;
                    N2 = N + M + 1;
                    N3 = N + N + 2;
                    N4 = N1 - 2;
                    N5 = N1 - 3;
                    A = this.PNK[N1];
                    AN = Math.floor(M + 1.5) * A;
                    CK1 = this.AR[N] * (this.C[J] * this.CO[M] + this.S[J] * this.SI[M]);
                    CK2 = this.AR[N] * (this.C[J] * this.SI[M] - this.S[J] * this.CO[M]);
                    if (N1 > 2)
                    {
                        this.PNK[N1 - 1] = Math.sqrt(N3 + 1) / (Math.sqrt(N4 + 1) * Math.sqrt(N2 + 2)) * (Math.sqrt(N3 - 1) *
                            SF * this.PNK[N4] - Math.sqrt(N2 + 1) * Math.sqrt(N5 + 1) / Math.sqrt(N3 - 3) * this.PNK[N5]);
                    }
                    else if (N1 == 0)
                    {                          //4.1.1
                        FR += this.HP[N] * CK1 * A;
                        FF -= CK1 * AN * TG;
                        FL += CK2 * AN;
                        J++;
                        continue;
                    }
                    if (N1 == 1)
                    {

                        this.PNK[0] = this.SK[N] * this.CF[N];
                    }
                    else if (N1 == 2)
                    {
                        this.PNK[1] = /*SQ[N3]*/ Math.sqrt(N3 + 1) * SF * this.PNK[0];
                    }
                    FR += this.HP[N] * CK1 * A;
                    FF += CK1 * (this.PNK[N1 - 1] */*SQ[N1-1]*SQ[N2+1]*/ Math.sqrt(N1) * Math.sqrt(N2 + 2) - TG * AN);
                    FL += CK2 * AN;
                    J++;
                }
                //               }     //4.1
            }     //4
            //    5
        }//0
        //   m5:
        FR = -GR * FR - this.R[2] * R3;
        FF = GR * FF;
        FL = -GR / this.CF[0] * FL;
        A = FF * SF;
        FX[0] = FR * (X * R1) - A * this.CO[0] - FL * this.SI[0];
        FY[0] = FR * (Y * R1) - A * this.SI[0] + FL * this.CO[0];
        FZ[0] = FR * SF + FF * this.CF[0];
    }

    sqrt(x: number): number {
        return Math.sqrt(x);
    }

}
