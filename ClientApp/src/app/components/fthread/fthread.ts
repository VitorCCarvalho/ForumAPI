import { Post } from '../post/post'
export interface FThread {
  id?: number
  forumID: number
  name: string
  text: string
  sticky?: boolean
  active?: boolean
  dateCreated?: Date
  startedByUserId?: string
  locked?: boolean
  posts?: Post[]
}
