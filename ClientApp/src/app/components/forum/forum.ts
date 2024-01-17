import { FThread } from '../fthread/fthread'
export interface Forum {
  id: Number
  name: string
  description: string
  threads: FThread[]
}

