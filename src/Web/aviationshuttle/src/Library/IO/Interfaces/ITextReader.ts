export interface ITextReader {
    readLine(): string
    readToEnd(): string
    eof(): boolean
    reset(): void
    getStrings(): string[]
}