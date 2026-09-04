export interface ISequenceFilter {

    getFilterCount(): number

    setFilterCount(count: number): void

    getFilterValue(a: number): number | undefined

    resetFilter(): void
}