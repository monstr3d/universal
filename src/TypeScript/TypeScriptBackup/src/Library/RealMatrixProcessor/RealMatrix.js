"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.RealMatrix = void 0;
const OwnError_1 = require("../ErrorHandler/OwnError");
class RealMatrix {
    createDiagonal(n, diag) {
        let m = [];
        for (var i = 0; i < n; i++) {
            let x = [];
            m.push(x);
            for (var j = 0; j < n; j++) {
                x.push(0);
            }
        }
        for (var i = 0; i < n; i++)
            m[i][i] = diag;
        return m;
    }
    partialSquare(x, startIndex, length) {
        let a = 0;
        for (let i = 0; i < length; i++) {
            let c = x[i + startIndex];
            a += c * c;
        }
        return a;
    }
    partialNorm(x, startIndex, length) {
        return Math.sqrt(this.partialSquare(x, startIndex, length));
    }
    plusEqual(x, y) {
        for (let i = 0; i < x.length; i++) {
            x[i] += y[i];
        }
    }
    setLength(x, n) {
        x.fill(0, 0, n - 1);
    }
    setLength2(x, n, m) {
        for (let i = 0; i < n; i++) {
            let y = [];
            this.setLength(y, m);
            x.push(y);
        }
    }
    normalize(inp, outp, offset) {
        let a = 0;
        for (let i = offset; i < outp.length + offset; i++) {
            let b = inp[i];
            a += b * b;
        }
        a = Math.sqrt(a);
        let c = 1 / a;
        for (let i = 0; i < outp.length; i++) {
            outp[i] = c * inp[i + offset];
        }
        return a;
    }
    getNorm(vector) {
        return Math.sqrt(this.square(vector));
    }
    copySign(a, b) {
        return Math.abs(a) * Math.sign(b);
    }
    invertA(a) {
        let x = [];
        var n = a.length;
        this.setLength2(x, n, n);
        this.invert(a, x);
        return x;
    }
    invert(a, aInverted) {
        let e = 0;
        let y = 0;
        let det = 0;
        let w = 0;
        let d = 0;
        let d1 = 0;
        let i = 0;
        let j = 0;
        let k = 0;
        let ir = 0;
        let ip = 0;
        let n = a.length;
        let jz = [];
        let c = [0];
        let ab = [0];
        jz.fill(0, 0, n - 1);
        c.fill(0, 0, n - 1);
        ab.fill(0, 0, n - 1);
        for (i = 0; i < n; i++) {
            for (j = 0; j < n; j++) {
                aInverted[i][j] = a[i][j];
            }
        }
        for (i = 0; i < n; i++) {
            for (j = 0; j < n; j++) {
                e = Math.abs(aInverted[i][j]);
                if (d < e)
                    d = e;
            }
        }
        d1 = 1 / d;
        for (i = 0; i < n; i++) {
            for (j = 0; j < n; j++) {
                aInverted[i][j] *= d1;
            }
        }
        e = 1.0e-26;
        det = 1;
        for (i = 0; i < n; i++) {
            jz[i] = i;
        }
        for (i = 0; i < n; i++) {
            k = i;
            y = aInverted[i][i];
            ir = i - 1;
            ip = i + 1;
            if (ip < n) {
                for (j = ip; j < n; j++) {
                    w = aInverted[i][j];
                    if (Math.abs(w) > Math.abs(y)) {
                        k = j;
                        y = w;
                    }
                }
            }
            det *= y;
            y = 1.0 / y;
            for (j = 0; j < n; j++) {
                c[j] = aInverted[j][k];
                aInverted[j][k] = aInverted[j][i];
                aInverted[j][i] = -c[j] * y;
                ab[j] = aInverted[i][j] * y;
                aInverted[i][j] = ab[j];
            }
            aInverted[i][i] = y;
            j = jz[i];
            jz[i] = jz[k];
            jz[k] = j;
            k = 0;
            do {
                if ((k <= ir) || (k >= ip)) {
                    j = 0;
                    do {
                        if ((j <= ir) || (j >= ip)) {
                            aInverted[k][j] -= ab[j] * c[k];
                        }
                        j++;
                    } while (j < n);
                }
                k++;
            } while (k < n);
        }
        i = 0;
        do {
            k = jz[i];
            if (k != i) {
                for (j = 0; j < n; j++) {
                    w = aInverted[i][j];
                    aInverted[i][j] = aInverted[k][j];
                    aInverted[k][j] = w;
                }
                ip = jz[i];
                jz[i] = jz[k];
                jz[k] = ip;
                det = -det;
            }
            else {
                i++;
            }
        } while (i < n);
        d1 = 1.0 / d;
        for (i = 0; i < n; i++) {
            for (j = 0; j < n; j++) {
                aInverted[i][j] *= d1;
            }
        }
    }
    det(a) {
        let A = [];
        let n = a.length;
        this.setLength2(A, n, n);
        for (let ii = 0; ii < n; ii++) {
            for (let jj = 0; jj < n; jj++) {
                A[ii][jj] = a[ii][jj];
            }
        }
        let bb = false;
        let MAX = 0;
        let D = 1;
        let T = 0;
        let k, i, j = 0;
        let z = 0;
        for (k = 0; k < n; k++) {
            MAX = 0;
            for (i = k; i < n; i++) {
                T = A[i][k];
                if (!(T == 0)) {
                    MAX = T;
                    j = i;
                    bb = true;
                }
                if (bb) {
                    break;
                }
            }
            if (MAX == 0) {
                return z;
            }
            if (j != k) {
                D = -D;
                for (i = k; i < n; i++) {
                    T = A[j][i];
                    A[j][i] = A[k][i];
                    A[k][i] = T;
                }
            }
            for (i = k + 1; i < n; i++) {
                T = A[i][k] / MAX;
                for (j = k + 1; j < n; j++) {
                    A[i][j] = A[i][j] - T * A[k][j];
                }
            }
            D = D * A[k][k];
        }
        return D;
    }
    scalarProduct(x, y) {
        let sum = 0;
        for (let i = 0; i < x.length; i++) {
            sum += x[i] * y[i];
        }
        return sum;
    }
    multiply(vector, coefficient) {
        for (let i = 0; i < vector.length; i++) {
            vector[i] = vector[i] * coefficient;
        }
    }
    multiplyMatrix(a, b, c) {
        let a1 = a.length;
        let a2 = a[0].length;
        let b1 = b.length;
        let b2 = b[0].length;
        let c1 = c.length;
        let c2 = c[0].length;
        if ((a2 != b1) || (a1 != c1) ||
            (b2 != c1)) {
            throw new OwnError_1.OwnError("Illegal matrix product dimension", "", "");
        }
        let i, j, k = 0;
        for (i = 0; i < c1; i++) {
            for (j = 0; j < c2; j++) {
                c[i][j] = 0;
            }
        }
        for (i = 0; i < a1; i++) {
            for (j = 0; j < b2; j++) {
                for (k = 0; k < a2; k++) {
                    c[i][j] += a[i][k] * b[k][j];
                }
            }
        }
    }
    square(vec) {
        let a = 0;
        for (let x of vec) {
            a += x * x;
        }
        return a;
    }
    norm(vec) {
        return Math.sqrt(this.square(vec));
    }
    multiplyRight(matrix, vector, product) {
        if ((matrix[0].length != vector.length) || (matrix.length != product.length)) {
            throw new OwnError_1.OwnError("Illegal dimension of vector or matrix product", "");
        }
        var i, j = 0;
        for (i = 0; i < product.length; i++) {
            product[i] = 0;
        }
        for (i = 0; i < matrix.length; i++) {
            for (j = 0; j < vector.length; j++) {
                product[i] += matrix[i][j] * vector[j];
            }
        }
    }
    multiplyLeft(vector, matrix, product) {
        if ((matrix.length != vector.length) || (matrix[0].length != product.length)) {
            throw new OwnError_1.OwnError("Illegal dimension of vector or matrix product", "");
        }
        let i, j = 0;
        for (i = 0; i < product.length; i++) {
            product[i] = 0;
        }
        for (i = 0; i < matrix[0].length; i++) {
            for (j = 0; j < vector.length; j++) {
                product[i] += matrix[j][i] * vector[j];
            }
        }
    }
    transpose(x, y) {
        for (let i = 0; i < x.length; i++) {
            for (let j = 0; j < x[0].length; j++) {
                y[j][i] = x[i][j];
            }
        }
    }
    htah(h, a, result) {
        for (let i = 0; i < result.length; i++) {
            for (let j = 0; j < result[0].length; j++) {
                result[i][j] = 0;
                for (let k = 0; k < a.length; k++) {
                    for (let l = 0; l < a[0].length; l++) {
                        result[i][j] += h[k][i] * a[k][l] * h[l][j];
                    }
                }
            }
        }
    }
    addMatrix(x, y, z) {
        for (let i = 0; i < x.length; i++) {
            for (let j = 0; j < x[0].length; j++) {
                z[i][j] = x[i][j] + y[i][j];
            }
        }
    }
    addVector(x, y, z) {
        for (let i = 0; i < x.length; i++) {
            z[i] = x[i] + y[i];
        }
    }
    diffatrix(x, y, z) {
        for (let i = 0; i < x.length; i++) {
            for (let j = 0; j < x[0].length; j++) {
                z[i][j] = x[i][j] - y[i][j];
            }
        }
    }
    diffVector(x, y, z) {
        for (let i = 0; i < x.length; i++) {
            z[i] = x[i] + y[i];
        }
    }
    lu_Factor(A, indx) {
        let i = 0, j = 0, k = 0;
        let jp = 0;
        let t = 0;
        let M = A.length;
        let N = A[0].length;
        let minMN = (M < N ? M : N);
        for (j = 0; j < minMN; j++) {
            // find pivot in column j and  test for singularity.
            jp = j;
            t = Math.abs(A[j][j]);
            for (i = j + 1; i < M; i++) {
                if (Math.abs(A[i][j]) > Math.abs(t)) {
                    jp = i;
                    t = Math.abs(A[i][j]);
                }
            }
            indx[j] = jp;
            // jp now has the index of maximum element
            // of column j, below the diagonal
            let zero = 0;
            if (A[jp][j] == zero) {
                return false; // factorization failed because of zero pivot
            }
            if (jp != j) // swap rows j and jp
             {
                for (k = 0; k < N; k++) {
                    t = A[j][k];
                    A[j][k] = A[jp][k];
                    A[jp][k] = t;
                }
            }
            if (j < M - 1) // compute elements j+1:M of jth column
             {
                // note A(j,j), was A(jp,p) previously which was
                // guarranteed not to be zero (Label #1)
                let y = 1;
                let recp = y / A[j][j];
                for (k = j + 1; k < M; k++) {
                    A[k][j] *= recp;
                }
            }
            if (j < minMN - 1) {
                // rank-1 update to trailing submatrix:   E = E - x*y;
                //
                // E is the region A(j+1:M, j+1:N)
                // x is the column vector A(j+1:M,j)
                // y is row vector A(j,j+1:N)
                let ii, jj = 0;
                for (ii = j + 1; ii < M; ii++) {
                    for (jj = j + 1; jj < N; jj++) {
                        A[ii][jj] -= A[ii][j] * A[j][jj];
                    }
                }
            }
        }
        return true;
    }
    lu_Solve(A, indx, b) {
        let i, ii = -1, ip = 0, j;
        let n = b.length;
        let sum = 0;
        for (i = 0; i < n; i++) {
            ip = indx[i];
            sum = b[ip];
            b[ip] = b[i];
            if (ii >= 0) {
                for (j = ii; j < i; j++) {
                    sum -= A[i][j] * b[j];
                }
            }
            else if (Math.abs(sum) > 0) {
                ii = i;
            }
            b[i] = sum;
        }
        for (i = n - 1; i >= 0; i--) {
            sum = b[i];
            for (j = i + 1; j < n; j++) {
                sum -= A[i][j] * b[j];
            }
            b[i] = sum / A[i][i];
        }
        return true;
    }
    solve(a, indx, b) {
        if (!this.lu_Factor(a, indx)) {
            return false;
        }
        if (!this.lu_Solve(a, indx, b)) {
            return false;
        }
        return true;
    }
}
exports.RealMatrix = RealMatrix;
//# sourceMappingURL=RealMatrix.js.map